using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.Shared.Game;
using WanderersDiary.Entities.Character;
using WanderersDiary.Entities.Models;

namespace WanderersDiary.Entities
{
    public class CharacterClass : EntityBase
    {
        public int Level { get; set; }

        public EClass Class { get; set; }

        /// Set in specific class business logic.
        public int Archetype { get; set; }

        /// <summary>
        /// Features that are selected from those available. Properties like uses count can by changed during level up.
        /// </summary>
        public ICollection<Feature> Features { get; set; }


    }
}
