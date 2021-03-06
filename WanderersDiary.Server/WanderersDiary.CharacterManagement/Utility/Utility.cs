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

        public static bool IsEqual<T>(T thisObject, T otherObject) where T : class
        {
            string serilizedThis = JsonConvert.SerializeObject(thisObject);
            string serializedOther = JsonConvert.SerializeObject(otherObject);

            return serilizedThis.Equals(serializedOther);
        }
    }
}
