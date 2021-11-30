using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.Contracts.Game;
using WanderersDiary.Entities.Models;
using WanderersDiary.Entities.Models.Character;

namespace WanderersDiary.Entities.Character
{
    public class Class : EntityBase
    {
        public string Name_EN { get; set; }

        public string Name_RU { get; set; }

        public string Description_EN { get; set; }

        public string Description_RU { get; set; }

        public EDice HitDice { get; set; }

        public ICollection<Feature> Features { get; set; }

        public Archetype Archetype { get; set; }

        public ICollection<ESkill> AvailiableSkills { get; set; }

        //REWORK TO DISCRETE TOOLS
        public ICollection<CommonProficiency> AvailiableTools { get; set; }

        public ICollection<ArmouryProficiencies> AvailiableArmouryProficiencies { get; set; }
    }
}
