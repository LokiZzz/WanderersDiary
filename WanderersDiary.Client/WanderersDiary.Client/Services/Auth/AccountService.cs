using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Client.Services.HTTP;
using WanderersDiary.Contracts.Auth;

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

        public async Task<SignInResponse> SignInAsync(string login, string password)
        {
            return await RestService.PostAsync<SignInRequest, SignInResponse>(
                @"https://192.168.50.40:44370/auth/sign-in",
                new SignInRequest
                {
                    Login = login,
                    Password = password
                }
            );
        }
    }
}
