﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Contracts.Auth
{
    public class SignInRequest
    {
        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
