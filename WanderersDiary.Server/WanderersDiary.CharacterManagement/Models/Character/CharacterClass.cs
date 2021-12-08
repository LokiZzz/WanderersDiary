using System.Collections.Generic;
using WanderersDiary.Shared.Game;

namespace WanderersDiary.CharacterManagement.Models
{
    public class CharacterClass
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
