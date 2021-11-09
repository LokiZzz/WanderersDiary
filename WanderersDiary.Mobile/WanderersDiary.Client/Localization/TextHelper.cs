using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WanderersDiary.Client.Resources;

namespace WanderersDiary.Client.Localization
{
    public static class TextHelper
    {
        public static string GetResource(string key)
        {
            LocalizedResources resources = new LocalizedResources(
                typeof(LanguageResources),
                CultureInfo.CurrentUICulture.TwoLetterISOLanguageName
            );

            return resources[key];
        }
    }
}
