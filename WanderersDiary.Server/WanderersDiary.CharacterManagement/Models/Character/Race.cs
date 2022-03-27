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

        public List<ESize> SizesToChooseFrom { get; set; }

        /// <summary>
        /// List of options player have to choose from.
        /// Player can choose only one option.
        /// </summary>
        public List<AttributesBonusesGroup> AttributesBonusesOptions { get; set; }

        public CharacterProficiencies Proficiencies { get; set; }

        public Speed Speed { get; set; }

        public Senses Senses { get; set; }

        public int HitPointsFactor { get; set; }

        public int? ReplaceIfBiggerArmorClass { get; set; }

        public int? OverridingArmorClass { get; set; }

        public List<Feature> Features { get; set; }

        public List<Race> Subraces { get; set; }
    }

    public class AttributesBonusesGroup
    {
        /// <summary>
        /// Bonuses that the player receives in full.
        /// </summary>
        public List<AttributeBonus> Bonuses { get; set; }
    }

    public class AttributeBonus
    {
        public int CountToSelect { get; set; }

        public int Bonus { get; set; }

        public List<EAttribute> AttributesToSelectFrom { get; set; }

        /// <summary>
        /// After every choice need to check if this field is True
        /// in other bonuses of group. If it is true, need to remove 
        /// choosed attribute from bonus setup.
        /// </summary>
        public bool MustBeOther { get; set; }
    }
}