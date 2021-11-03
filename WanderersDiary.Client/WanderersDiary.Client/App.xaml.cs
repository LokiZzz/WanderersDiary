using Prism;
using Prism.Ioc;
using System;
using WanderersDiary.Client.Navigation;
using WanderersDiary.Client.ViewModels;
using WanderersDiary.Client.ViewModels.Auth;
using WanderersDiary.Client.ViewModels.Common;
using WanderersDiary.Client.Views;
using WanderersDiary.Client.Views.Auth;
using WanderersDiary.Client.Views.Common;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using static WanderersDiary.Client.Navigation.NavigationParametersNames.Common;

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
