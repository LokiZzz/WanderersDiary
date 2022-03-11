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
    }
}
