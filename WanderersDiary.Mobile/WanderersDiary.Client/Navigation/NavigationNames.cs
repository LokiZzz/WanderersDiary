using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.Client.Views.Auth;
using WanderersDiary.Client.Views.Common;

namespace WanderersDiary.Client.Navigation
{
    public static class NavigationNames
    {
        internal static class Common
        {
            public static readonly string Error = nameof(ErrorPage);
        }

        internal static class Auth
        {
            public static readonly string SignIn = nameof(SignInPage);
            public static readonly string SignUp = nameof(SignUpPage);
        }
    }
}
