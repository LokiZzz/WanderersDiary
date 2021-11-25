using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Contracts.Auth;
using WanderersDiary.Entities;
using WanderersDiary.Entities.Models.Auth;
using WanderersDiary.Entities.Models.User;

namespace WanderersDiary.API.Services.Auth
{
    public interface IJwtGenerator
    {
        Task<CreateTokenResult> CreateTokenAsync(Wanderer user);

        Task<VerifyTokenResult> VerifyTokenAsync(TokenRequest tokenRequest);
    }

    public class JwtGenerator : IJwtGenerator
    {
        private readonly SymmetricSecurityKey _key;
        private readonly WDDbContext _dbContext;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly UserManager<Wanderer> _userManager;

        public JwtGenerator(IConfiguration config, 
            WDDbContext dbCOntext, 
            TokenValidationParameters tokenValidationParameters,
            UserManager<Wanderer> userManager)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _dbContext = dbCOntext;
            _tokenValidationParameters = tokenValidationParameters;
            _userManager = userManager;
        }

        public async Task<CreateTokenResult> CreateTokenAsync(Wanderer user)
        {
            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SigningCredentials credentials = new(_key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            RefreshToken refreshToken = await CreateRefreshTokenAsync(user, token);

            return new CreateTokenResult
            {
                Token = tokenHandler.WriteToken(token),
                TokenExpirationUtcDate = token.ValidTo,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpirationUtcDate = refreshToken.ExpiryDate
            };
        }       

        public async Task<VerifyTokenResult> VerifyTokenAsync(TokenRequest tokenRequest)
        {
            try
            {
                VerifyTokenResult result = ValidateAccessTokenAsync(tokenRequest, out ClaimsPrincipal principal);

                if(result.IsSuccess)
                {
                    RefreshToken storedRefreshToken = await _dbContext
                        .RefreshTokens
                        .Include(rt => rt.User)
                        .FirstOrDefaultAsync(x => x.Token == tokenRequest.RefreshToken);

                    result = ValidateRefreshTokenAsync(storedRefreshToken, principal);

                    if (result.IsSuccess)
                    {
                        storedRefreshToken.IsUsed = true;
                        _dbContext.RefreshTokens.Update(storedRefreshToken);
                        await _dbContext.SaveChangesAsync();

                        Wanderer dbUser = await _userManager.FindByIdAsync(storedRefreshToken.User.Id);

                        result = new VerifyTokenResult
                        {
                            TokenResult = await CreateTokenAsync(dbUser),
                            IsSuccess = true
                        };
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private VerifyTokenResult ValidateAccessTokenAsync(TokenRequest tokenRequest, out ClaimsPrincipal principal)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new();

            // Validate format
            _tokenValidationParameters.ValidateLifetime = false;
            principal = jwtTokenHandler.ValidateToken(
                tokenRequest.Token,
                _tokenValidationParameters,
                out var validatedToken
            );
            _tokenValidationParameters.ValidateLifetime = true;

            // Validate algorithm
            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);

                if (result == false)
                {
                    return GetBadVerifyTokenResult("Wrong security algorithm.");
                }
            }

            // Validate the access token expired
            if (principal.GetExpiryDate() > DateTime.UtcNow)
            {
                return GetBadVerifyTokenResult("We cannot refresh this since the token has not expired.");
            }

            return new VerifyTokenResult { IsSuccess = true };
        }

        private VerifyTokenResult ValidateRefreshTokenAsync(RefreshToken storedRefreshToken, ClaimsPrincipal principal)
        {
            // Validate token exists
            if (storedRefreshToken == null)
            {
                return GetBadVerifyTokenResult("Refresh token doesnt exist.");
            }

            // Validate the refresh token has not expired
            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
            {
                return GetBadVerifyTokenResult("Refresh token has expired, user needs to relogin.");
            }

            // Validate the refresh token has not been used
            if (storedRefreshToken.IsUsed)
            {
                return GetBadVerifyTokenResult("Token has been used.");
            }

            // Validate the refresh token is not been revoked
            if (storedRefreshToken.IsRevoked)
            {
                return GetBadVerifyTokenResult("Token has been revoked.");
            }

            // Validate access token id matched
            string jti = principal.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            if (storedRefreshToken.JWTId != jti)
            {
                return GetBadVerifyTokenResult("The token doesn't matched the saved token.");
            }

            return new VerifyTokenResult { IsSuccess = true };
        }

        private static VerifyTokenResult GetBadVerifyTokenResult(string error)
        {
            return new VerifyTokenResult()
            {
                Errors = new List<string>() { error },
                IsSuccess = false
            };
        }

        private async Task<RefreshToken> CreateRefreshTokenAsync(Wanderer user, SecurityToken token)
        {
            RefreshToken refreshToken = new RefreshToken
            {
                JWTId = token.Id,
                IsUsed = false,
                User = user,
                ExpiryDate = DateTime.UtcNow.AddMonths(1),
                IsRevoked = false,
                Token = Guid.NewGuid().ToString()
            };

            await _dbContext.RefreshTokens.AddAsync(refreshToken);
            await _dbContext.SaveChangesAsync();

            return refreshToken;
        }
    }

    public class VerifyTokenResult
    {
        public CreateTokenResult TokenResult { get; set; }

        public bool IsSuccess { get; set; }

        public List<string> Errors { get; set; }
    }

    public class CreateTokenResult
    {
        public string Token { get; set; }

        public DateTime TokenExpirationUtcDate { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpirationUtcDate { get; set; }
    }
}
