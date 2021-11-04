using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Text;
using WanderersDiary.Client.Localization;
using Xamarin.Forms;

namespace WanderersDiary.Client.Resources
{
    //How to use:

    //CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);
    //CultureInfo.CurrentUICulture = new CultureInfo("ru-RU", false);
    //MessagingCenter.Send<object, CultureChangedMessage>(sender: this, message: string.Empty, args: new CultureChangedMessage(CultureInfo.CurrentUICulture));

    //<Button Text="{Binding Resources[SignInPage_SignIn]}"/>

    public class LocalizedResources : INotifyPropertyChanged
    {
        private const string DEFAULT_LANGUAGE = "en";

        private readonly ResourceManager ResourceManager;
        private CultureInfo CurrentCultureInfo;

        public string this[string key]
        {
            get
            {
                return ResourceManager.GetString(key, CurrentCultureInfo);
            }
        }

        public LocalizedResources(Type resource, string language = null)
            : this(resource, new CultureInfo(language ?? DEFAULT_LANGUAGE)) { }

        public LocalizedResources(Type resource, CultureInfo cultureInfo)
        {
            CurrentCultureInfo = cultureInfo;
            ResourceManager = new ResourceManager(resource);

            MessagingCenter.Subscribe<object, CultureChangedMessage>(this,
                string.Empty, OnCultureChanged);
        }

        private void OnCultureChanged(object s, CultureChangedMessage ccm)
        {
            CurrentCultureInfo = ccm.NewCultureInfo;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
