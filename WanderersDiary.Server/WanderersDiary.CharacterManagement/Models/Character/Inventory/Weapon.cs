using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Enums;
using WanderersDiary.CharacterManagement.Models.Game;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Weapon : Equipment
    {
        public List<EWeaponType> Categories { get; set; }

        public List<Damage> Damage { get; set; } = new List<Damage>();

        public List<EWeaponProperty> Properties { get; set; } = new List<EWeaponProperty>();

        public Range Range { get; set; }

        public List<Damage> Versatile { get; set; }

        public new EEquipmentType Type => EEquipmentType.Weapon;
    }

    public class Range
    {
        public int WODis { get; set; }

        public int Max { get; set; }
    }

    public enum EWeaponProperty
    {
        Ammunition = 1,
        Finesse = 2,
        Heavy = 3,
        Light = 4, 
        Loading = 5,
        Reach = 6,
        Special = 7,
        Thrown = 8,
        TwoHanded = 9,
        Versatile = 10
    }

    public enum EWeaponType
    {
        Simple = 1,
        Martial = 2,
        Melee = 3,
        Ranged = 4,
        Firearm = 5
    }
}
