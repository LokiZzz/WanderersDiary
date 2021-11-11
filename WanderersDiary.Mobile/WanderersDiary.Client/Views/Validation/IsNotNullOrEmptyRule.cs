using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Client.Views.Validation
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            string str = $"{value}";

            return !string.IsNullOrWhiteSpace(str);
        }
    }
}
