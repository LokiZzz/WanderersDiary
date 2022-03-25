using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Models;

namespace WanderersDiary.CharacterManagement.Static
{
    public class StaticCollectionBase<C,T>
    {
        public static List<T> GetAll()
        {
            System.Reflection.FieldInfo[] fields = typeof(C).GetFields();

            return fields.Select(f => (T)f.GetValue(null)).ToList();
        }

        public static Dictionary<string,T> GetWithStaticFieldNames()
        {
            System.Reflection.FieldInfo[] fields = typeof(C).GetFields();
            Dictionary<string, T> dict = new Dictionary<string, T>();

            foreach (var item in fields)
            {
                dict.Add(item.Name, (T)item.GetValue(null));
            }

            return dict;
        }
    }
}
