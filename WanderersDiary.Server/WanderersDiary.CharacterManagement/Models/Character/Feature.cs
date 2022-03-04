using System;
using System.Collections.Generic;
using WanderersDiary.CharacterManagement.Models.Enums;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Feature
    {
        /// <summary>
        /// Id, unique for class, using to bind DB data to business logic classes.
        /// </summary>
        public int Index { get; set; }

        public LocalizedString Name { get; set; }

        public LocalizedString Description { get; set; }

        public ERest ResetAfter { get; set; }

        /// <summary>
        /// 1 for features and abilities not binded to level.
        /// </summary>
        public int LevelToGain { get; set; }

        public List<int> LevelWhenUpdate { get; set; }

        /// <summary>
        /// -1 for not not limited uses, if equal to Max, then is over.
        /// </summary>
        public int SpentUses { get; set; }

        /// <summary>
        /// -1 for not limited uses.
        /// </summary>
        public int MaxUses { get; set; } = -1;

        public int MinimumOfMaxUses { get; set; } = 0;

        public Func<Character, int> GetMaxUses { get; set; }

        public void UpdateMaxUses(Character character)
        {
            if(GetMaxUses != null)
            {
                MaxUses = GetMaxUses(character);

                if(MaxUses < MinimumOfMaxUses)
                {
                    MaxUses = MinimumOfMaxUses;
                }
            }
        }
    }
}
