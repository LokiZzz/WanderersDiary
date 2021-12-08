using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Shared.Auth
{
    public class TokenRequest
    {
        public string Token { get; set; }
     
        public string RefreshToken { get; set; }
    }
}
