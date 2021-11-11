using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Java.Util.ResourceBundle;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using WanderersDiary.Client.Android.Renderers;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace WanderersDiary.Client.Android.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            Control.BackgroundTintList = ColorStateList.ValueOf(e.NewElement.TextColor.ToAndroid());
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "TextColor")
            {
                Entry entry = (Entry)sender;
                Control.BackgroundTintList = ColorStateList.ValueOf(entry.TextColor.ToAndroid());
            }
        }
    }
}