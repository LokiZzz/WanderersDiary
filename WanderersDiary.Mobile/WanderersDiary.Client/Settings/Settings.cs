using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Client
{
    public static class Settings
    {
        public static class Auth
        {
            public static readonly string Token = nameof(Token);
            public static readonly string RefreshToken = nameof(Token);
        }
    }
}
