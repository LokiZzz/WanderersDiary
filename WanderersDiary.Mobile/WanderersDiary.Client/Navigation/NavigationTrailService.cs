using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using WanderersDiary.Client.Services.Auth;
using Xamarin.Essentials;

namespace WanderersDiary.Client.Navigation
{
    public interface INavigationTrailService
    {
        NavigationTrail GetOnStartTrail();

        NavigationTrail GetTrailFromAppLink(Uri uri);
    }

    public class NavigationTrailService : INavigationTrailService
    {
        public IAccountService AccountService { get; }

        public NavigationTrailService(IAccountService accountService)
        {
            AccountService = accountService;
        }

        public NavigationTrail GetOnStartTrail()
        {
            if (AccountService.IsUserSignedIn())
            {
                return new NavigationTrail { Path = NavigationNames.Common.Main };
            }
            else
            {
                return new NavigationTrail { Path = NavigationNames.Auth.SignIn };
            }
        }

        public NavigationTrail GetTrailFromAppLink(Uri uri)
        {
            string intentString = HttpUtility.ParseQueryString(uri.Query).Get("intent");

            if(Enum.TryParse(intentString, out EAppLinkIntent intent))
            {
                switch(intent)
                {
                    case EAppLinkIntent.ConfirmEmail:
                        return GetConfirmEmailTrail(uri);
                    default:
                        return GetOnStartTrail();
                }
            }
            else
            {
                return GetOnStartTrail();
            }
        }

        private NavigationTrail GetConfirmEmailTrail(Uri uri)
        {
            NavigationParameters parameters = new NavigationParameters();

            parameters.Add(
                NavigationParametersNames.EmailConfirmation.UserId,
                HttpUtility.ParseQueryString(uri.Query).Get("userid")
            );
            parameters.Add(
                NavigationParametersNames.EmailConfirmation.Token,
                HttpUtility.ParseQueryString(uri.Query).Get("token")
            );

            return new NavigationTrail
            {
                Path = NavigationNames.Auth.ConfirmEmail,
                Parameters = parameters,
                IsModal = true
            };
        }
    }

    public enum EAppLinkIntent
    {
        ConfirmEmail = 1,
        ResetPassword = 2
    }

    public class NavigationTrail
    {
        public string Path { get; set; }

        public NavigationParameters Parameters { get; set; }

        public bool? IsModal { get; set; }
    }
}
