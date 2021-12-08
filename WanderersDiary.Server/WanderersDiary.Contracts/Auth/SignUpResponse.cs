using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Shared.Auth
{
    public class SignUpResponse
    {
        public bool IsSuccess { get; set; }

        public List<ESignUpErrors> Errors { get; set; }
    }

    public enum ESignUpErrors
    {
        Unknown = 0,
        LoginExists = 1,
        EmailExists = 2,
        PasswordDoesNotMatchRequirements = 3
    }
}
