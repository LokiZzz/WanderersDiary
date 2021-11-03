﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Contracts.Auth
{
    public class ResetPasswordRequest
    {
        public string UserName { get; set; }

        public string Token { get; set; }

        public string NewPassword { get; set; }
    }
}
