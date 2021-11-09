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

            if(response.IsSuccess)
            {
                Preferences.Set(Settings.Auth.Token, response.Token);
                Preferences.Set(Settings.Auth.RefreshToken, response.Token);
            }

            return response;
        }
    }
}
