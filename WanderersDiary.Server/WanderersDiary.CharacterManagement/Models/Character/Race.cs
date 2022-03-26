using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Enums;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Race
    {
        public LocalizedString Name { get; set; }

        public ESize Size { get; set; }

        public List<EAttribute> AttributesBonuses { get; set; }

        public CharacterProficiencies Proficiencies { get; set; }

        public Speed Speed { get; set; }

        public Senses Senses { get; set; }

        public int HitPointsFactor { get; set; }

        public int? ReplaceIfBiggerArmorClass { get; set; }

        public int? OverridingArmorClass { get; set; }

        public List<Feature> Features { get; set; }

        public List<Race> Subraces { get; set; }
    }
}
