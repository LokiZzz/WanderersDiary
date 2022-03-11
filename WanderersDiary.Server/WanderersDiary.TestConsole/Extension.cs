using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.CharacterManagement.Models;

namespace WanderersDiary.TestConsole
{
    public static class Extension
    {
        public static EEquipmentType ToType(this string type)
        {
            type = type.Replace(" ", string.Empty);
            type = type.ToLowerInvariant();

            switch (type)
            {
                case "arcanefocus": return EEquipmentType.ArcaneFocus;
                case "druidicfocus": return EEquipmentType.DruidicFocus;
                case "hollysymbol": return EEquipmentType.HolySymbol;
                case "hollysimbol": return EEquipmentType.HolySymbol;
                case "ammunition": return EEquipmentType.Ammunition;
                case "camp": return EEquipmentType.Camp;
                case "clothes": return EEquipmentType.Clothes;
                case "consumables": return EEquipmentType.Consumable;
                case "container": return EEquipmentType.Container;
                case "gear": return EEquipmentType.Gear;
                case "kit": return EEquipmentType.Kit;
                case "tool": return EEquipmentType.Tool;

                default: throw new ArgumentException("Wrong type!");
            }
        }

        public static string ToFullString(this EEquipmentType type) => $"EEquipmentType.{type.ToString("G")}";
    }
}
