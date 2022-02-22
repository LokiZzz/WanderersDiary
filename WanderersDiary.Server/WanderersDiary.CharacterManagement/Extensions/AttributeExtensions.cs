using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.Shared.Game;

namespace WanderersDiary.CharacterManagement.Extensions
{
    public static class AttributeExtensions
    {
        public static int Modifier(this int attribute)
        {
            decimal modifier = Convert.ToDecimal(attribute - 10) / 2;
            decimal floored = Math.Floor(modifier);

            return Convert.ToInt32(floored);
        }

        public static int Average(this EDice eDice)
        {
            decimal average = Convert.ToDecimal(1 + (int)eDice) / 2;
            decimal floored = Math.Ceiling(average);

            return Convert.ToInt32(floored);
        }

        public static int Max(this EDice eDice) => (int)eDice;
    }
}
