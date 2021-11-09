using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Client.Services.Auth;
using WanderersDiary.Contracts.Auth;

namespace WanderersDiary.Client.ViewModels.Auth
{
    public class SignUpPageVM : ViewModelBase
    {
        public IAccountService AccountService { get; }

        public SignUpPageVM(INavigationService navigationService,
            IAccountService accountService) : base(navigationService) 
        {
            SignUpCommand = new DelegateCommand(async () => await ExecuteSignUp());
            AccountService = accountService;
        }

        private async Task ExecuteSignUp()
        {
            IsBusy = true;

            IsErrorVisible = false;
            SignUpResponse response = await AccountService.SignUpAsync(Login, Password, Email);

            if (response?.IsSuccess == true)
            {
                //Navigate to "please, confirm email" message page
            }
            else if (response?.IsSuccess == false)
            {
                IsErrorVisible = true;
                ErrorText = GetErrorText(response.Errors);
            }

            IsBusy = false;
        }

        private string GetErrorText(List<ESignUpErrors> errors)
        {
            string errorText = string.Empty;

            if (errors != null)
            {
                foreach (ESignUpErrors error in errors)
                {
                    if(!string.IsNullOrEmpty(errorText))
                    {
                        errorText += Environment.NewLine;
                    }

                    switch (error)
                    {
                        case ESignUpErrors.EmailExists:
                            errorText += Resources["SignUpPage_EmailExists"];
                            break;
                        case ESignUpErrors.LoginExists:
                            errorText += Resources["SignUpPage_LoginExists"];
                            break;
                        case ESignUpErrors.PasswordDoesNotMatchRequirements:
                            errorText += Resources["SignUpPage_PasswordRequirementsError"];
                            break;
                    }
                }
            }

            return errorText;
        }

        public DelegateCommand SignUpCommand { get; set; }

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

        private string _repeatPassword;
        public string RepeatPassword
        {
            get { return _repeatPassword; }
            set { SetProperty(ref _repeatPassword, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
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
    }
}
