using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WanderersDiary.Client.Services
{
    public interface IThemeService
    {
        void InitializeTheme();

        void ChangeTheme(ETheme theme);
    }

    public class ThemeService : IThemeService
    {
        public void InitializeTheme()
        {
            ETheme theme = (ETheme)Preferences.Get(Settings.App.Theme, 0);

            if(theme == 0)
            {
                Application.Current.Resources.MergedDictionaries.Add(new PurpleTheme());
                Preferences.Set(Settings.App.Theme, (int)ETheme.Purple);
            }

            ChangeTheme(theme);
        }

        public void ChangeTheme(ETheme theme)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            if (mergedDictionaries != null)
            {
                mergedDictionaries.ClearTheme();

                switch (theme)
                {
                    case ETheme.Purple:
                        mergedDictionaries.Add(new PurpleTheme());
                        break;
                    case ETheme.Gold:
                    default:
                        mergedDictionaries.Add(new GoldTheme());
                        break;
                }

                Preferences.Set(Settings.App.Theme, (int)theme);
            }
        }
    }

    public enum ETheme
    {
        Purple = 1,
        Gold = 2
    }

    public static class ResourceDictionaryExtensions
    {
        public static void ClearTheme(this ICollection<ResourceDictionary> mergedDictionaries)
        {
            List<ResourceDictionary> dictionariesToDelete = new List<ResourceDictionary>();

            foreach (var dictionary in mergedDictionaries)
            {
                if (dictionary?.Source?.OriginalString?.Contains("Styles") == false)
                {
                    dictionariesToDelete.Add(dictionary);
                }
            }

            dictionariesToDelete.ForEach(d => mergedDictionaries.Remove(d));
        }
    }

}
