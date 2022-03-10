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
            switch (type)
            {
                case "ArcaneFocus": return EEquipmentType.ArcaneFocus;
                case "DruidicFocus": return EEquipmentType.DruidicFocus;
                case "HollySymbol": return EEquipmentType.HolySymbol;
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
    }
}
