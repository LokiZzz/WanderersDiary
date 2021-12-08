using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Shared.Auth
{
    public class SignUpRequest
    {
        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
