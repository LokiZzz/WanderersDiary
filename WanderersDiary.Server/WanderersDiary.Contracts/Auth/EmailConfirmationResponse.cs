using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Contracts.Auth
{
    public class EmailConfirmationResponse
    {
        public bool IsSuccess { get; set; }

        public List<EEmailConfirmationError> Errors { get; set; }
    }

    public enum EEmailConfirmationError
    {
        TokenExpired = 1
    }
}
