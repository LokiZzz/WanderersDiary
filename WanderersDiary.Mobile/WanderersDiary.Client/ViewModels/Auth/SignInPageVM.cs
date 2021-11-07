using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Client.Localization;
using WanderersDiary.Client.Services.Alert;
using WanderersDiary.Client.Services.Auth;
using WanderersDiary.Contracts.Auth;
using Xamarin.Forms;

namespace WanderersDiary.Client.ViewModels.Auth
{
    public class SignInPageVM : ViewModelBase
    {
        public IAccountService AccountService { get; }
        public IAlertService AlertService { get; }

        public SignInPageVM(INavigationService navigationService, 
            IAccountService accountService) 
            : base(navigationService)
        {
            SignInCommand = new DelegateCommand(async () => await ExecuteSignIn());
            AccountService = accountService;
            AlertService = DependencyService.Get<IAlertService>();
        }

        private async Task ExecuteSignIn()
        {
            Login = "lokizzz5";
            Password = "03Dragonfly#03";

            SignInResponse response = await AccountService.SignInAsync(Login, Password);

            if (response.IsSuccess)
                AlertService.LongAlert("Success");
            else
                AlertService.LongAlert("Fail");
        }

        public DelegateCommand SignInCommand { get; set; }

        #region Bindable properties

        private string _login;
        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        #endregion
    }
}
