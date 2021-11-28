using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Client.Localization;
using WanderersDiary.Client.Navigation;
using WanderersDiary.Client.Resources;
using WanderersDiary.Client.Services;
using WanderersDiary.Client.Services.Alert;
using WanderersDiary.Client.Services.Auth;
using WanderersDiary.Contracts.Auth;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WanderersDiary.Client.ViewModels.Auth
{
    public class SignInPageVM : ViewModelBase
    {
        public IAccountService AccountService { get; }
        public IThemeService ThemeService { get; }
        public INavigationService Navigation { get; }
        public IAlertService AlertService { get; }

        public SignInPageVM(INavigationService navigationService, 
            IAccountService accountService, 
            IThemeService themeService,
            INavigationService navigation) : base(navigationService)
        {
            SignInCommand = new DelegateCommand(async () => await ExecuteSignIn());
            SignUpCommand = new DelegateCommand(async () => await ExecuteSignUp());

            AccountService = accountService;
            ThemeService = themeService;
            Navigation = navigation;
            AlertService = DependencyService.Get<IAlertService>();

            Login = "loki123123";
            Password = "123456";
        }

        private async Task ExecuteSignUp()
        {
            await NavigationService.TryNavigateAsync(NavigationNames.Auth.SignUp);
        }

        public bool CanSignIn => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);

        private async Task ExecuteSignIn()
        {
            IsBusy = true;

            IsErrorVisible = false;
            SignInResponse response = await AccountService.SignInAsync(Login, Password);

            if (response?.IsSuccess == true)
            {
                await Navigation.TryNavigateAsync(
                    path: NavigationNames.Common.Main.ToAbsolutePath(),
                    isModal: true
                );
            }
            else if(response?.IsSuccess == false)
            {
                IsErrorVisible = true;
                ErrorText = GetErrorText(response.Errors);
            }

            IsBusy = false;
        }

        public DelegateCommand SignInCommand { get; set; }
        public DelegateCommand SignUpCommand { get; set; }

        #region Bindable properties

        private string _login;
        public string Login
        {
            get { return _login; }
            set 
            { 
                SetProperty(ref _login, value);
                SignInCommand.RaiseCanExecuteChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
                SignInCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _isErrorVisible = false;
        public bool IsErrorVisible
        {
            get { return _isErrorVisible; }
            set { SetProperty(ref _isErrorVisible, value); }
        }

        private string _errorText;
        public string ErrorText
        {
            get { return _errorText; }
            set { SetProperty(ref _errorText, value); }
        }

        #endregion

        private string GetErrorText(List<ESignInError> errors)
        {
            string errorText = string.Empty;

            if (errors != null)
            {
                foreach (ESignInError error in errors)
                {
                    switch (error)
                    {
                        case ESignInError.EmailNotConfirmed:
                            errorText += Resources["SignInPage_ConfirmEmailError"];
                            break;
                        case ESignInError.InvalidLoginOrPassword:
                            errorText += Resources["SignInPage_InvalidPasswordError"];
                            break;
                    }
                }
            }

            return errorText;
        }
    }
}
