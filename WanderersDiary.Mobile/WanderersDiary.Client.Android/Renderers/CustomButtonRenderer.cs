using System;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using WanderersDiary.Client.Android.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace WanderersDiary.Client.Android.Renderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context) { }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                FixRipple(button);
            }

            base.OnElementPropertyChanged(sender, e);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            FixRipple(e.NewElement);
        }

        private void FixRipple(Button element)
        {
            if (element != null && Control != null)
            {
                float density = Math.Max(1, Resources.DisplayMetrics.Density);
                Button button = element;
                float cornerRadius = button.CornerRadius * density;
                double borderWidth = button.BorderWidth * density;

                // Create a new background drawable that looks same as the current one
                LinearGradientBrush background = button.Background as LinearGradientBrush;
                GradientDrawable normal = GetNewGradientDrawable(button, cornerRadius, borderWidth, background);

                // Use a mask drawable to ensure Ripple respects the buttons' rounded corners
                PaintDrawable mask = new PaintDrawable();
                mask.SetCornerRadius(cornerRadius);

                int defaultRippleColor = GetIntFromFormsColor(Xamarin.Forms.Color.White);

                RippleDrawable rippleDrawable =
                    new RippleDrawable(ColorStateList.ValueOf(new Color(defaultRippleColor)),
                        normal,
                        mask);

                GradientDrawable disabled = GetNewGradientDrawable(button, cornerRadius, borderWidth, background);
                SetDisabledStyle(button, disabled, borderWidth);

                // Add the drawables to a state list and assign the state list to the button
                StateListDrawable sld = new StateListDrawable();

                // Important to have only Enabled state here - using Normal/Pressed states for example would prevent the Ripple from showing
                // The RippleDrawable shows fade in on touch down, and fade out plus ripple out from hotspot on touch up anyway.
                sld.AddState(new int[] { global::Android.Resource.Attribute.StateEnabled }, rippleDrawable);

                // Needs to include the negated int value of the state so that a drawable is also visible when the button is disabled.
                sld.AddState(new int[] { -global::Android.Resource.Attribute.StateEnabled }, disabled);

                Control.SetBackground(sld);
                Control.SetTextColor(Element.TextColor.ToAndroid());

                // Without this we get a material drop shadow animation, whether Elevation is set or not
                Control.StateListAnimator = null;
            }
        }

        private void SetDisabledStyle(Button button, GradientDrawable drawable, double borderWidth)
        {
            drawable.SetColorFilter(new PorterDuffColorFilter(Color.LightGray, PorterDuff.Mode.Multiply));

            //if (button.BackgroundColor.A != -1)
            //{
            //    if (button.BackgroundColor.A == 0)
            //    {
            //        Xamarin.Forms.Color color = button.BorderColor.WithLuminosity(0.5);
            //        drawable.SetStroke((int)borderWidth, color.ToAndroid());
            //    }
            //    else
            //    {
            //        Xamarin.Forms.Color color = button.BackgroundColor.WithLuminosity(0.5);
            //        drawable.SetColor(color.ToAndroid());
            //    }
            //}
        }

        private static GradientDrawable GetNewGradientDrawable(Button button, float cornerRadius, double borderWidth, LinearGradientBrush background)
        {
            GradientDrawable drawable = new GradientDrawable(
                GradientDrawable.Orientation.TlBr,
                background.GradientStops.Select(
                    s => GetIntFromFormsColor(s.Color)
                ).ToArray()
            );
            drawable.SetStroke((int)borderWidth, button.BorderColor.ToAndroid());
            drawable.SetCornerRadius(cornerRadius);

            if (button.BackgroundColor.A == 0)
            {
                drawable.SetColor(button.BackgroundColor.ToAndroid());
            }

            return drawable;
        }

        private static int GetIntFromFormsColor(Xamarin.Forms.Color color)
        {
            string hexString = color.ToHex();
            hexString = hexString.Replace("#", string.Empty);
            int parsedInt = int.Parse(hexString, System.Globalization.NumberStyles.HexNumber);

            return parsedInt;
        }
    }
}