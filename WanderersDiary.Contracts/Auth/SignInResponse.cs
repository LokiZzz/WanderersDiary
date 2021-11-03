using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Contracts.Auth
{
    public class SignInResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public bool IsSuccess { get; set; }

        public List<string> Errors { get; set; }
    }
}
