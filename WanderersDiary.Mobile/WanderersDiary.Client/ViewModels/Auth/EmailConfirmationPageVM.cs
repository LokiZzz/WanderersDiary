using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.Client.Services.Alert;
using WanderersDiary.Client.Services.Auth;
using WanderersDiary.Client.Services;
using Xamarin.Forms.Internals;
using Xamarin.Forms;
using WanderersDiary.Client.Navigation;
using Prism.Common;

namespace WanderersDiary.Client.ViewModels.Auth
{
    public class EmailConfirmationPageVM : ViewModelBase
    {
        public IAccountService AccountService { get; }
        public IAlertService AlertService { get; }

        public EmailConfirmationPageVM(INavigationService navigationService, IAccountService accountService) 
            : base(navigationService)
        {
            AccountService = accountService;
            AlertService = DependencyService.Get<IAlertService>();
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Contracts.Auth.EmailConfirmationResponse response = await AccountService.ConfirmEmailAsync(
                parameters.GetValue<string>(NavigationParametersNames.EmailConfirmation.UserId),
                parameters.GetValue<string>(NavigationParametersNames.EmailConfirmation.Token)
            );
        }
    }
}
