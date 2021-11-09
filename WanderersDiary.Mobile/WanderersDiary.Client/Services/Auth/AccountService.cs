using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Client.Services.HTTP;
using WanderersDiary.Contracts.Auth;
using Xamarin.Essentials;

namespace WanderersDiary.Client.Services.Auth
{
    public interface IAccountService
    {
        Task<SignInResponse> SignInAsync(string login, string password);
        Task<SignUpResponse> SignUpAsync(string login, string password, string email);
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
                Preferences.Set(Settings.Auth.RefreshToken, response.Token);
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
    }
}
