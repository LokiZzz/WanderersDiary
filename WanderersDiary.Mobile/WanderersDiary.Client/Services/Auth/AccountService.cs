using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Client.Services.HTTP;
using WanderersDiary.Contracts.Auth;
using Xamarin.Essentials;
using Xamarin.Forms.Internals;

namespace WanderersDiary.Client.Services.Auth
{
    public interface IAccountService
    {
        Task<SignInResponse> SignInAsync(string login, string password);
        Task<SignUpResponse> SignUpAsync(string login, string password, string email);
        Task<EmailConfirmationResponse> ConfirmEmailAsync(string userId, string token);
        bool IsUserSignedIn();
    }

    public class AccountService : IAccountService
    {
        public IRestService RestService { get; }

        public AccountService(IRestService restService)
        {
            RestService = restService;
        }

        public string FullPath(string path) => App.ServerAddress + path;

        public async Task<SignInResponse> SignInAsync(string login, string password)
        {
            SignInResponse response = await RestService.PostAsync<SignInRequest, SignInResponse>(
                FullPath("/auth/sign-in"),
                new SignInRequest
                {
                    Login = login,
                    Password = password
                }
            );

            if(response?.IsSuccess == true)
            {
                Preferences.Set(Settings.Auth.Token, response.Token);
                Preferences.Set(Settings.Auth.TokenValidTo, response.TokenExpirationUtcDate);
                Preferences.Set(Settings.Auth.RefreshToken, response.Token);
                Preferences.Set(Settings.Auth.RefreshTokenValidTo, response.RefreshTokenExpirationUtcDate);
            }

            return response;
        }

        public async Task<SignUpResponse> SignUpAsync(string login, string password, string email)
        {
            SignUpResponse response = await RestService.PostAsync<SignUpRequest, SignUpResponse>(
                FullPath("/auth/sign-up"),
                new SignUpRequest
                {
                    Login = login,
                    Password = password,
                    Email = email
                }
            );

            return response;
        }

        public async Task<EmailConfirmationResponse> ConfirmEmailAsync(string userId, string token)
        {
            EmailConfirmationResponse response = await RestService.PostAsync<ConfirmEmailRequest, EmailConfirmationResponse>(
                FullPath("/auth/confirm-email"),
                new ConfirmEmailRequest
                {
                    UserId = userId,
                    Token = token
                }
            );

            return response;
        }

        public bool IsUserSignedIn()
        {
            string token = Preferences.Get(Settings.Auth.Token, null);
            DateTime tokenValidTo = Preferences.Get(Settings.Auth.TokenValidTo, DateTime.MinValue);

            return !string.IsNullOrEmpty(token) && tokenValidTo > DateTime.UtcNow;
        }
    }
}
