using System.Collections.Generic;
using WanderersDiary.CharacterManagement.Models.Enums;

namespace WanderersDiary.CharacterManagement.Models
{
    public class CharacterRace
    {
        public ERace Race { get; set; }

        public int HitPointsFactor { get; set; }

        public int? ReplaceIfBiggerArmorClass { get; set; }

        public int? OverridingArmorClass { get; set; }

        /// <summary>
        /// Subrace is another feature specified in race business logic.
        /// </summary>
        public List<Feature> Features { get; set; }
    }
}
