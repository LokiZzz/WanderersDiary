using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WanderersDiary.Client.Views.Validation
{
    public class ValidatablePair<T> : IValidatable<ValidatablePair<T>>
    {
        public List<IValidationRule<ValidatablePair<T>>> Validations { get; } = new List<IValidationRule<ValidatablePair<T>>>();

        public bool IsValid { get; set; } = true;

        public List<string> Errors { get; set; } = new List<string>();

        public ValidatableValue<T> Item1 { get; set; } = new ValidatableValue<T>();

        public ValidatableValue<T> Item2 { get; set; } = new ValidatableValue<T>();

        public event PropertyChangedEventHandler PropertyChanged;

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
    }
}
