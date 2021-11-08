using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Client.Localization;
using WanderersDiary.Client.Resources;
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
        public IAlertService AlertService { get; }

        public SignInPageVM(INavigationService navigationService, 
            IAccountService accountService) 
            : base(navigationService)
        {
            SignInCommand = new DelegateCommand(async () => await ExecuteSignIn());
            ChangeThemeCommand = new DelegateCommand(() => ExecuteChangeTheme());

            AccountService = accountService;
            AlertService = DependencyService.Get<IAlertService>();
        }

        private void ExecuteChangeTheme()
        {  
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                var dictionariesToDelete = new List<ResourceDictionary>();
                foreach(var dictionary in mergedDictionaries)
                {
                    if(dictionary?.Source?.OriginalString?.Contains("Styles") == false)
                    {
                        dictionariesToDelete.Add(dictionary);
                    }
                }
                dictionariesToDelete.ForEach(d => mergedDictionaries.Remove(d));

                ETheme theme = (ETheme)Preferences.Get(Settings.App.Theme, 0);
                theme = theme == 0 || theme == ETheme.Purple ? ETheme.Gold : ETheme.Purple;

                switch (theme)
                {
                    case ETheme.Purple:
                        mergedDictionaries.Add(new PurpleTheme());
                        break;
                    case ETheme.Gold:
                    default:
                        mergedDictionaries.Add(new GoldTheme());
                        break;
                }

                Preferences.Set(Settings.App.Theme, (int)theme);
            }
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

        #endregion
    }
}
