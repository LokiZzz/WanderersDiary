using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Client.Navigation;
using WanderersDiary.Client.Services.Auth;
using WanderersDiary.Client.Views.Validation;
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
            AddValidationRules();
        }

        private async Task ExecuteSignUp()
        {
            if(!AreFieldsValid())
            {
                return;
            }

            IsBusy = true;

            IsErrorVisible = false;
            SignUpResponse response = await AccountService.SignUpAsync(Login.Value, Password.Item1.Value, Email.Value);

            if (response?.IsSuccess == true)
            {
                await NavigateToAskUserConfirmEmail();
            }
            else if (response?.IsSuccess == false)
            {
                IsErrorVisible = true;
                ErrorText = GetErrorText(response.Errors);
            }

            IsBusy = false;
        }

        private async Task NavigateToAskUserConfirmEmail()
        {
            NavigationParameters parameters = new NavigationParameters();
            parameters.Add(NavigationParametersNames.Common.UserMessagePage.Title, Resources["Message_ConfirmEmail_Title"]);
            parameters.Add(NavigationParametersNames.Common.UserMessagePage.Message, Resources["Message_ConfirmEmail"]);

            NavigationTrail trailAfter = new NavigationTrail() { Path = NavigationNames.Auth.SignIn };
            parameters.Add(NavigationParametersNames.Common.UserMessagePage.TrailAfter, trailAfter);

            await NavigationService.TryNavigateAsync(NavigationNames.Common.Message, parameters);
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

        bool AreFieldsValid() =>  Email.Validate() && Login.Validate() && Password.Validate();

        public void AddValidationRules()
        {
            Login.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = Resources["SignUpPage_LoginRequired"] });

            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = Resources["SignUpPage_EmailRequired"] });
            Email.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = Resources["SignUpPage_EmailInvalid"] });

            Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = Resources["SignUpPage_EnterPassword"] });
            Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = Resources["SignUpPage_ConfirmPassword"] });
            Password.Validations.Add(new MatchPairValidationRule<string> { ValidationMessage = Resources["SignUpPage_PasswordsDoesntMatch"] });
        }

        public ValidatableValue<string> Login { get; set; } = new ValidatableValue<string>();
        public ValidatableValue<string> Email { get; set; } = new ValidatableValue<string>();
        public ValidatablePair<string> Password { get; set; } = new ValidatablePair<string>();

        //private string _login;
        //public string Login
        //{
        //    get { return _login; }
        //    set { SetProperty(ref _login, value); }
        //}

        //private string _password;
        //public string Password
        //{
        //    get { return _password; }
        //    set { SetProperty(ref _password, value); }
        //}

        //private string _repeatPassword;
        //public string RepeatPassword
        //{
        //    get { return _repeatPassword; }
        //    set { SetProperty(ref _repeatPassword, value); }
        //}

        //private string _email;
        //public string Email
        //{
        //    get { return _email; }
        //    set { SetProperty(ref _email, value); }
        //}

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
