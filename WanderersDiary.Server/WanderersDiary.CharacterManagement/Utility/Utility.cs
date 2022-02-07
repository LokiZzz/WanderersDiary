using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.CharacterManagement
{
    public static class Utility
    {
        public static T Copy<T>(this T objectToCopy) where T : class 
        {
            string serilizedString = JsonConvert.SerializeObject(objectToCopy);

            return JsonConvert.DeserializeObject<T>(serilizedString);
        }
    }
}
