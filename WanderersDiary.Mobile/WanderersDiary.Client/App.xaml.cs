using Prism;
using Prism.Ioc;
using System;
using WanderersDiary.Client.Navigation;
using WanderersDiary.Client.Resources;
using WanderersDiary.Client.Services;
using WanderersDiary.Client.Services.Auth;
using WanderersDiary.Client.Services.HTTP;
using WanderersDiary.Client.ViewModels;
using WanderersDiary.Client.ViewModels.Auth;
using WanderersDiary.Client.ViewModels.Common;
using WanderersDiary.Client.Views;
using WanderersDiary.Client.Views.Auth;
using WanderersDiary.Client.Views.Common;
using Xamarin.Essentials;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace WanderersDiary.Client
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            INavigationTrailService trailService = Container.Resolve<INavigationTrailService>();
            NvaigationTrail trail = trailService.GetOnStartTrail();

            Container.Resolve<IThemeService>().InitializeTheme();

            await NavigationService.NavigateAsync(NavigationNames.Auth.SignIn);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            RegisterUtilityServices(containerRegistry);
            RegisterForNavigation(containerRegistry);
        }

        private void RegisterUtilityServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterScoped<INavigationTrailService, NavigationTrailService>();
            containerRegistry.RegisterSingleton<IRestService, RestService>();
            containerRegistry.RegisterSingleton<IAccountService, AccountService>();
            containerRegistry.RegisterSingleton<IThemeService, ThemeService>();
        }

        private static void RegisterForNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            //Common
            containerRegistry.RegisterForNavigation<ErrorPage, ErrorPageVM>();

            //Auth
            containerRegistry.RegisterForNavigation<SignInPage, SignInPageVM>();
        }
    }
}
