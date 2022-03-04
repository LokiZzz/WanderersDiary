using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Enums;
using WanderersDiary.CharacterManagement.Models.Game;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Weapon : InventoryItem
    {
        public List<Damage> Damage { get; set; } = new List<Damage>();

        public List<EWeaponTags> Tags { get; set; } = new List<EWeaponTags>();

        public Range Range { get; set; }
    }

    public class Range
    {
        public int Min { get; set; }

        public int Max { get; set; }
    }
}
