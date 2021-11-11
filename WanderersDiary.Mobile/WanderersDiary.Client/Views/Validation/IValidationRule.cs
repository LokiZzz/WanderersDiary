using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Client.Views.Validation
{
    public interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }
        bool Check(T value);
    }
}
