using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Client.Localization;
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
        public IAlertService AlertService { get; }

        public SignInPageVM(INavigationService navigationService, 
            IAccountService accountService, IThemeService themeService) 
            : base(navigationService)
        {
            SignInCommand = new DelegateCommand(async () => await ExecuteSignIn());
            ChangeThemeCommand = new DelegateCommand(() => ExecuteChangeTheme());

            AccountService = accountService;
            ThemeService = themeService;
            AlertService = DependencyService.Get<IAlertService>();

            Login = "lokizzz5";
            Password = "03Dragonfly#03";
        }

        bool isPurple = false;
        bool isEnglish = false;

        private void ExecuteChangeTheme()
        {
            ETheme theme = isPurple ? ETheme.Purple : ETheme.Gold;
            isPurple = !isPurple;

            ThemeService.ChangeTheme(theme);

            CultureInfo.CurrentUICulture = isEnglish ? new CultureInfo("ru-RU", false) : new CultureInfo("en-US", false);
            MessagingCenter.Send<object, CultureChangedMessage>(sender: this, message: string.Empty, args: new CultureChangedMessage(CultureInfo.CurrentUICulture));
            isEnglish = !isEnglish;
        }

        private async Task ExecuteSignIn()
        {
            IsBusy = true;

            IsErrorVisible = false;
            SignInResponse response = await AccountService.SignInAsync(Login, Password);

            if (response.IsSuccess)
            {
                //Navigate to main page
            }
            else
            {
                IsErrorVisible = true;
                ErrorText = GetErrorText(response.Errors);
            }

            IsBusy = false;
        }

        public DelegateCommand SignInCommand { get; set; }
        public DelegateCommand ChangeThemeCommand { get; set; }

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

        private bool _isErrorVisible;
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

            return errorText;
        }
    }
}
