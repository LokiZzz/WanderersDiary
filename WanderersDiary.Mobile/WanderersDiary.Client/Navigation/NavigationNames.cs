using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.Client.Views.Auth;
using WanderersDiary.Client.Views.Common;
using WanderersDiary.Client.Views.Main;

namespace WanderersDiary.Client.Navigation
{
    public static class NavigationNames
    {
        internal static class Common
        {
            public static readonly string Main = nameof(MainPage);
            public static readonly string Error = nameof(ErrorPage);
            public static readonly string Message = nameof(UserMessagePage);
        }

        internal static class Auth
        {
            public static readonly string SignIn = nameof(SignInPage);
            public static readonly string SignUp = nameof(SignUpPage);
            public static readonly string ConfirmEmail = nameof(EmailConfirmationPage);
        }
    }
}
