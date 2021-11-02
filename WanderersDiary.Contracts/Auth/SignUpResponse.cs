using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Contracts.Auth
{
    public class SignUpResponse
    {
        public bool IsSuccess { get; set; }

        public List<string> Errors { get; set; }
    }
}
