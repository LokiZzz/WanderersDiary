using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Client.Localization;
using Xamarin.Forms;

namespace WanderersDiary.Client.ViewModels.Auth
{
    public class SignInPageVM : ViewModelBase
    {
        public SignInPageVM(INavigationService navigationService) : base(navigationService)
        {
            SwitchLanguageCommand = new DelegateCommand(ExecuteSwitchLanguage);
            SignInCommand = new DelegateCommand(async () => await ExecuteSignIn());
        }

        private Task ExecuteSignIn()
        {
            throw new NotImplementedException();
        }

        private void ExecuteSwitchLanguage()
        {
            if (CultureInfo.CurrentUICulture.Name == "ru-RU")
            {
                CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);
            }
            else
            {
                CultureInfo.CurrentUICulture = new CultureInfo("ru-RU", false);
            }

            MessagingCenter.Send<object, CultureChangedMessage>(
                sender: this, 
                message: string.Empty, 
                args: new CultureChangedMessage(CultureInfo.CurrentUICulture)
            );
        }

        public DelegateCommand SwitchLanguageCommand { get; set; }
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

        private string _response;
        public string Response
        {
            get { return _response; }
            set { SetProperty(ref _response, value); }
        }

        #endregion
    }
}
