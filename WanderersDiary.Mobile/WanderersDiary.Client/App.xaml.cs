using Prism;
using Prism.Ioc;
using Prism.Unity;
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

[assembly: ExportFont("PlayfairDisplay-VariableFont_wght.ttf", Alias = "PlayfairDisplay")]
[assembly: ExportFont("SourceSansPro-Regular.ttf", Alias = "SourceSansPro")]

namespace WanderersDiary.Client
{
    public partial class App : PrismApplication
    {
        #if DEBUG
        public static readonly string ServerAddress = "https://192.168.50.40:44370";
        #endif
        #if !DEBUG
        public static readonly string ServerAddress = "";
        #endif

        public App(IPlatformInitializer initializer)
            : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            Container.Resolve<IThemeService>().InitializeTheme();

            INavigationTrailService trailService = Container.Resolve<INavigationTrailService>();
            NavigationTrail trail = trailService.GetOnStartTrail();

            await NavigationService.TryNavigateAsync(trail.Path, trail.Parameters, trail.IsModal);
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
            containerRegistry.RegisterForNavigation<UserMessagePage, UserMessagePageVM>();

            //Auth
            containerRegistry.RegisterForNavigation<SignInPage, SignInPageVM>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageVM>();

        }
    }
}
