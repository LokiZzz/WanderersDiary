using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Classes;
using WanderersDiary.CharacterManagement.Models;

namespace WanderersDiary.CharacterManagement
{
    public static class CharacterClassFactory
    {
        public static Dictionary<EClass, Type> Classes = new Dictionary<EClass, Type>
        {
            { EClass.Bard, typeof(Bard) }
        };

        public static ClassBase GetClass(EClass characterClass)
        {
            Type type = Classes[characterClass];

            return (ClassBase)Activator.CreateInstance(type);
        }
    }
}
