using System;
using System.ComponentModel;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using MyProject.Droid.Renderers;
using WanderersDiary.Client.Resources.Visual;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer), new[] { typeof(RippleButtonVisual) })]
namespace MyProject.Droid.Renderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context) { }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if(e.PropertyName.Contains("Color"))
            {
                FixRipple((Button)sender);
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            FixRipple(e.NewElement);
        }

        private void FixRipple(Button e)
        {
            if (e != null && Control != null)
            {
                var density = Math.Max(1, Resources.DisplayMetrics.Density);
                var button = e;
                var cornerRadius = button.CornerRadius * density;
                var borderWidth = button.BorderWidth * density;

                // Create a new background drawable that looks same as the current one
                var normal = new GradientDrawable();
                normal.SetColor(button.BackgroundColor.ToAndroid());
                normal.SetStroke((int)borderWidth, button.BorderColor.ToAndroid());
                normal.SetCornerRadius(cornerRadius);

                // Use a mask drawable to ensure Ripple respects the buttons' rounded corners
                var mask = new PaintDrawable();
                mask.SetCornerRadius(cornerRadius);
                mask.SetBounds((int)button.Bounds.Left, (int)button.Bounds.Top, (int)button.Bounds.Right, (int)button.Bounds.Bottom);

                // Use default Android ripple color
                TypedValue outValue = new TypedValue();
                Context.Theme.ResolveAttribute(Android.Resource.Attribute.ColorControlHighlight, outValue, true);
                var defaultRippleColor = Context.GetColor(outValue.ResourceId);

                var rippleDrawable = new RippleDrawable(ColorStateList.ValueOf(
                    new Android.Graphics.Color(defaultRippleColor)),
                    normal,
                    mask
                );

                // Add the drawables to a state list and assign the state list to the button
                var sld = new StateListDrawable();

                // Important to have only Enabled state here - using Normal/Pressed states for example would prevent the Ripple from showing
                // The RippleDrawable shows fade in on touch down, and fade out plus ripple out from hotspot on touch up anyway.
                sld.AddState(new int[] { Android.Resource.Attribute.StateEnabled }, rippleDrawable);

                Control.SetBackground(sld);

                // Without this we get a material drop shadow animation, whether Elevation is set or not
                Control.StateListAnimator = null;
            }
        }
    }
}