using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Enums;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Armor : InventoryItem
    {
        public EArmorType Type { get; set; }

        public int? StrenghtRequirement { get; set; }

        public int BaseAC { get; set; }

        public bool HaveDexterityModifier { get; set; }

        public int? MaxDexterityBonus { get; set; }

        public bool HaveStealthDisadvantage { get; set; }
    }
}
