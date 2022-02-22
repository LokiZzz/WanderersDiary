using System.Collections.Generic;
using WanderersDiary.CharacterManagement.Classes;
using WanderersDiary.Shared.Game;

namespace WanderersDiary.CharacterManagement.Models
{
    public class CharacterClass
    {
        public int Level { get; set; }

        public EClass Class { get; set; }

        public Archetype Archetype { get; set; }

        public List<Archetype> ArchetypesToSelectFrom { get; set; }

        public List<Feature> Features { get; set; } = new List<Feature>();

        /// <summary>
        /// Exists only during leveling up, contains groups of features that user have to select from.
        /// If user select feature, its group will be deleted instantly.
        /// </summary>
        public List<List<Feature>> FeatureGroupsToSelectFrom { get; set; } = new List<List<Feature>>();

        public int HitPointsFactor { get; set; }
    }
}
