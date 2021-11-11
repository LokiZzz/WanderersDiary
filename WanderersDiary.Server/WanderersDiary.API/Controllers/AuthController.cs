using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using WanderersDiary.API.Services.Auth;
using WanderersDiary.API.Services.Email;
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
        public IEmailService EmailService { get; }

        public AuthController(ILogger<AuthController> logger,
            UserManager<Wanderer> userManager,
            SignInManager<Wanderer> signInManager,
            IJwtGenerator jwtGenerator,
            IEmailService emailService)
        {
            _logger = logger;
            UserManager = userManager;
            SignInManager = signInManager;
            JwtGenerator = jwtGenerator;
            EmailService = emailService;
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<ActionResult<SignInResponse>> SignInAsync(SignInRequest request)
        {
            Wanderer user = await UserManager.FindByNameAsync(request.Login);
            if (user == null)
            {
                return new SignInResponse
                {
                    IsSuccess = false,
                    Errors = new List<ESignInError> { ESignInError.InvalidLoginOrPassword }
                };
            }

            if (!user.EmailConfirmed)
            {
                return new SignInResponse 
                { 
                    IsSuccess = false, 
                    Errors = new List<ESignInError> { ESignInError.EmailNotConfirmed } 
                };
            }

            SignInResult result = await SignInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {               
                CreateTokenResult tokenResult = await JwtGenerator.CreateTokenAsync(user);

                return new SignInResponse 
                { 
                    IsSuccess = true,
                    Token = tokenResult.Token, 
                    RefreshToken = tokenResult.RefreshToken 
                };
            }
            else
            {
                return new SignInResponse 
                { 
                    IsSuccess = false, 
                    Errors = new List<ESignInError> { ESignInError.Other } 
                };
            }
        }

        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<ActionResult<SignUpResponse>> SignUpAsync(SignUpRequest request)
        {
            Wanderer newUser = new Wanderer { Email = request.Email, UserName = request.Login };
            IdentityResult result = await UserManager.CreateAsync(newUser);

            if(result.Succeeded)
            {
                result = await UserManager.AddPasswordAsync(newUser, request.Password);

                if (result.Succeeded)
                {
                    string confirmationToken = await UserManager.GenerateEmailConfirmationTokenAsync(newUser);
                    string confirmationLink = GetEmailConfirmationURL(newUser.Id, confirmationToken);
                    await EmailService.SendAsync(newUser.Email, new EmailMessage { Subject = "Confirm email", HtmlContent = confirmationLink });

                    return new SignUpResponse { IsSuccess = true };
                }
            }
            
            return new SignUpResponse 
            { 
                IsSuccess = false, 
                Errors = result.Errors.Select(e => e.ToSignUpError()).ToList() 
            };
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest tokenRequest)
        {
            VerifyTokenResult res = await JwtGenerator.VerifyTokenAsync(tokenRequest);

            if (res == null)
            {
                return BadRequest();
            }

            return Ok(res);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailRequest request)
        {
            Wanderer user = UserManager.FindByIdAsync(request.UserId).Result;
            IdentityResult result = await UserManager.ConfirmEmailAsync(user, request.Token);

            return result.Succeeded ? Ok() : BadRequest();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("request-password-reset")]
        public async Task<IActionResult> RequestPasswordReset(string username)
        {
            Wanderer user = await UserManager.FindByNameAsync(username);

            if (user == null || user?.EmailConfirmed != true)
            {
                BadRequest("User not found.");
            }

            string token = await UserManager.GeneratePasswordResetTokenAsync(user);
            await EmailService.SendAsync(
                user.Email, 
                new EmailMessage { Subject = "Reset password", HtmlContent = token }
            );

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            Wanderer user = await UserManager.FindByNameAsync(request.UserName);

            IdentityResult result = await UserManager.ResetPasswordAsync(
                user, 
                request.Token, 
                request.NewPassword
            );

            return result.Succeeded ? Ok() : BadRequest();
        }

        [HttpGet("check")]
        public async Task<string> Get()
        {
            Wanderer user = await UserManager.FindByIdAsync(User.GetId());

            return $"{user.UserName} ({user.Id})";
        }

        private string GetEmailConfirmationURL(string userId, string confirmationToken)
        {
            string currentController = ControllerContext.RouteData.Values["controller"].ToString();

            return Url.Action(
                action: nameof(ConfirmEmail), 
                controller: currentController, 
                values: new ConfirmEmailRequest
                { 
                    UserId = userId, 
                    Token = confirmationToken 
                }, 
                protocol: HttpContext.Request.Scheme
            );
        }
    }
}
