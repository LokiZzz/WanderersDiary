﻿using WanderersDiary.Shared.Game;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Feature
    {
        public string Name_EN { get; set; }

        public string Name_RU { get; set; }

        public string Description_EN { get; set; }

        public string Description_RU { get; set; }

        /// <summary>
        /// -1 for not not limited uses, if equal to Max, then is over.
        /// </summary>
        public int CurrentUses { get; set; }
        
        /// <summary>
        /// -1 for not limited uses.
        /// </summary>
        public int MaxUses { get; set; }

        public ERest ResetAfter { get; set; }

        /// <summary>
        /// 1 for features and abilities not binded to level.
        /// </summary>
        public int LevelToGain { get; set; }
    }
}
