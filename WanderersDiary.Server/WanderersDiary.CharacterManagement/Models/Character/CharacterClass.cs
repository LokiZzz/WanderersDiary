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
        public List<Feature> Features { get; set; } = new List<Feature>();

        /// <summary>
        /// Exists only during leveling up, contains groups of features that user have to select from.
        /// If user select feature, its group will be deleted instantly.
        /// </summary>
        public List<List<Feature>> FeatureGroupsToSelectFrom { get; set; } = new List<List<Feature>>();
    }
}
