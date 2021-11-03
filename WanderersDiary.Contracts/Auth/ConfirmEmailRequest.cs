using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Contracts.Auth
{
    public class ConfirmEmailRequest
    {
        public string UserId { get; set; }

        public string Token { get; set; }
    }
}
