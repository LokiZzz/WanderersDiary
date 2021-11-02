using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WanderersDiary.API.Services.Auth;
using WanderersDiary.Contracts.Auth;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace WanderersDiary.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }
        public IJwtGenerator JwtGenerator { get; }

        public AuthController(ILogger<AuthController> logger,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IJwtGenerator jwtGenerator)
        {
            _logger = logger;
            UserManager = userManager;
            SignInManager = signInManager;
            JwtGenerator = jwtGenerator;
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<ActionResult<SignInResponse>> SignInAsync(SignInRequest request)
        {
            IdentityUser user = await UserManager.FindByEmailAsync(request.Login);
            if (user == null)
            {
                return Unauthorized();
            }

            SignInResult result = await SignInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                return new SignInResponse { Token = JwtGenerator.CreateToken(user)};
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult<SignUpResponse>> SignUpAsync(SignInRequest request)
        {
            IdentityUser newUser = new IdentityUser { Email = request.Email, UserName = request.Login };
            IdentityResult result = await UserManager.CreateAsync(newUser);

            if(result.Succeeded)
            {
                await UserManager.AddPasswordAsync(newUser, request.Password);

                return new SignUpResponse { IsSuccess = true };
            }
            else
            {
                return new SignUpResponse 
                { 
                    IsSuccess = false, 
                    Errors = result.Errors.Select(e => e.Description).ToList() 
                };
            }
        }

        [HttpGet("check")]
        public string Get()
        {
            return User.GetId();
        }
    }
}
