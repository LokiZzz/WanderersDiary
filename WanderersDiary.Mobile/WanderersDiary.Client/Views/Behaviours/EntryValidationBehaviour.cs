using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WanderersDiary.Client.Views.Behaviours
{
    public class EntryValidationBehaviour : BehaviorBase<Entry>
    {
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(
            nameof(IsValid), 
            typeof(bool), 
            typeof(EntryValidationBehaviour),
            true, 
            BindingMode.Default, 
            null, 
            (bindable, oldValue, newValue) => OnIsValidChanged(bindable, newValue)
        );

        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
        }

        private static void OnIsValidChanged(BindableObject bindable, object newValue)
        {
            if (bindable is EntryValidationBehaviour IsValidBehavior && newValue is bool IsValid)
            {
                VisualStateManager.GoToState(IsValidBehavior.AssociatedObject, IsValid ? "Valid" : "Invalid");
            }
        }
    }
}
