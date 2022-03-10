using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.CharacterManagement.Models
{
    public class EquipmentItem : InventoryItem
    {
        public EEquipmentType Type { get; set; }
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
        Kit = 11
    }
}
