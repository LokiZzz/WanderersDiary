using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Enums;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Armor : Equipment
    {
        public EArmorType Category { get; set; }

        public int? StrenghtRequirement { get; set; }

        public int BaseAC { get; set; }

        public bool HaveDexterityModifier { get; set; }

        public int? MaxDexterityBonus { get; set; }

        public bool HaveStealthDisadvantage { get; set; }

        public new EEquipmentType Type => EEquipmentType.Armor;
    }

    public enum EArmorType
    {
        Light = 1,
        Medium = 2,
        Heavy = 3,
        Shield = 4,
        Additional = 5
    }
}
