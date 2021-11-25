using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Contracts.Auth
{
    public class SignInResponse
    {
        public string Token { get; set; }

        public DateTime TokenExpirationUtcDate { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpirationUtcDate { get; set; }

        public bool IsSuccess { get; set; }

        public List<ESignInError> Errors { get; set; }
    }

    public enum ESignInError
    {
        InvalidLoginOrPassword = 1,
        EmailNotConfirmed = 2,
        Other = 3
    }
}
