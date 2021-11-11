using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WanderersDiary.Client.Views.Validation
{
    public class ValidatableValue<T> : BindableBase, IValidatable<T>
    {
        public List<IValidationRule<T>> Validations { get; } = new List<IValidationRule<T>>();

        private List<string> _errors = new List<string>();
        public List<string> Errors
        {
            get => _errors;
            set => SetProperty(ref _errors, value);
        }

        public bool CleanOnChange { get; set; } = true;

        T _value;
        public T Value
        {
            get => _value;
            set
            {
                SetProperty(ref _value, value);

                if (CleanOnChange)
                {
                    IsValid = true;
                }
            }
        }

        private bool _isValid = true;
        public bool IsValid
        {
            get => _isValid;
            set => SetProperty(ref _isValid, value);
        }

        public virtual bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = Validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return IsValid;
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        public DelegateCommand ValidateCommand => new DelegateCommand(() => Validate());
    }
}
