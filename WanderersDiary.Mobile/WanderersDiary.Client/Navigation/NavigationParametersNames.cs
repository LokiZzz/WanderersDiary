using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Client.Navigation
{
    public static class NavigationParametersNames
    {
        public static class EmailConfirmation
        {
            public static readonly string UserId = nameof(UserId);
            public static readonly string Token = nameof(Token);
        }

        public static class Common
        {
            internal static class ErrorPageParameters
            {
                public static readonly string Error = nameof(Error);
            }

            internal static class UserMessagePage
            {
                public static readonly string Title = nameof(Title);
                public static readonly string Message = nameof(Message); 
                public static readonly string TrailAfter = nameof(TrailAfter);
            }
        }
    }
}
