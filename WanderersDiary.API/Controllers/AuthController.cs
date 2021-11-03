using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WanderersDiary.API.Services.Auth;
using WanderersDiary.Contracts.Auth;
using WanderersDiary.Entities.Models.User;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace WanderersDiary.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public UserManager<Wanderer> UserManager { get; }
        public SignInManager<Wanderer> SignInManager { get; }
        public IJwtGenerator JwtGenerator { get; }

        public AuthController(ILogger<AuthController> logger,
            UserManager<Wanderer> userManager,
            SignInManager<Wanderer> signInManager,
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
            Wanderer user = await UserManager.FindByEmailAsync(request.Login);
            if (user == null)
            {
                return Unauthorized();
            }

            SignInResult result = await SignInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                CreateTokenResult tokenResult = await JwtGenerator.CreateTokenAsync(user);

                return new SignInResponse { Token = tokenResult.Token, RefreshToken = tokenResult.RefreshToken };
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult<SignUpResponse>> SignUpAsync(SignUpRequest request)
        {
            Wanderer newUser = new Wanderer { Email = request.Email, UserName = request.Login };
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

        [AllowAnonymous]
        [HttpPost]
        [Route("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest tokenRequest)
        {
            VerifyTokenResult res = await JwtGenerator.VerifyTokenAsync(tokenRequest);

            if (res == null)
            {
                return BadRequest();
            }

            return Ok(res);
        }

        [HttpGet("check")]
        public string Get()
        {
            return User.GetId();
        }
    }
}
