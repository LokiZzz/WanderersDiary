﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Client.Views.Validation
{
    public class IsValidEmailRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress($"{value}");

                return addr.Address == $"{value}";
            }
            catch
            {
                return false;
            }
        }
    }
}
