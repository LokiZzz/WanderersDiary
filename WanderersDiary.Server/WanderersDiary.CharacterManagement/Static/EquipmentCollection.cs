using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Static
{
    public static class EquipmentCollection
    {
        public static EquipmentItem Item = new EquipmentItem
        {
            Name = new LocalizedString { EN = "", RU = "" },
            Description = new LocalizedString { EN = "", RU = "" },
            Price = 0.0m,
            Weight = 0.0m,
            Type = EEquipmentType.Tool
        };
    }
}
