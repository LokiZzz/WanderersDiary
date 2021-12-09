using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.CharacterManagement.Extensions
{
    public static class AttributeExtensions
    {
        public static int Modifier(this int attribute)
        {
            return (attribute - 10) / 2;
        }
    }
}
