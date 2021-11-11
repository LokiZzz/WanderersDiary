using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WanderersDiary.Client.Views.Validation
{
    public class ValidatablePair<T> : BindableBase, IValidatable<ValidatablePair<T>>
    {
        public List<IValidationRule<ValidatablePair<T>>> Validations { get; } = new List<IValidationRule<ValidatablePair<T>>>();

        private bool _isValid = true;
        public bool IsValid
        {
            get => _isValid;
            set => SetProperty(ref _isValid, value);
        }

        private List<string> _errors = new List<string>();
        public List<string> Errors
        {
            get => _errors;
            set => SetProperty(ref _errors, value);
        }

        public ValidatableValue<T> Item1 { get; set; } = new ValidatableValue<T>();

        public ValidatableValue<T> Item2 { get; set; } = new ValidatableValue<T>();

        public bool Validate()
        {
            bool item1IsValid = Item1.Validate();
            bool item2IsValid = Item2.Validate();

            if (item1IsValid && item2IsValid)
            {
                Errors.Clear();

                IEnumerable<string> errors = Validations.Where(v => !v.Check(this))
                    .Select(v => v.ValidationMessage);

                Errors = errors.ToList();
                Item2.Errors = Errors;
                Item2.IsValid = !Errors.Any();
            }

            IsValid = !Item1.Errors.Any() && !Item2.Errors.Any();

            return IsValid;
        }

        public DelegateCommand ValidateCommand => new DelegateCommand(() => Validate());
    }
}
