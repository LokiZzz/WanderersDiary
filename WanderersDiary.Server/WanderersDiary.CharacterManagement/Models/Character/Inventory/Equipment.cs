using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Equipment
    {
        public LocalizedString Name { get; set; }

        public LocalizedString Description { get; set; }

        public string Note { get; set; }

        public decimal? Price { get; set; }

        public decimal? Weight { get; set; }

        public int Quantity { get; set; } = 1;

        public EEquipmentType Type { get; set; }

        public List<Equipment> Content { get; set; }
    }

    public enum EEquipmentType
    {
        Ammunition = 1,
        Consumable = 2,
        Tool = 3,
        Gear = 4,
        Container = 5,
        ArcaneFocus = 6,
        DruidicFocus = 7,
        HolySymbol = 8,
        Clothes = 9,
        Camp = 10,
        Kit = 11,
        Weapon = 12,
        Armor = 13
    }
}
