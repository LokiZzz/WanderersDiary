﻿using System;
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

        public int AvailiableSkillNumber { get; set; }
        public ICollection<ESkill> Skills { get; set; }

        public ICollection<CommonProficiency> Tools { get; set; }

        public ArmouryProficiencies ArmouryProficiencies { get; set; }

        public bool StrenghtSave { get; set; }
        public bool DexteritySave { get; set; }
        public bool ConstitutionSave { get; set; }
        public bool IntelligenceSave { get; set; }
        public bool WisdomSave { get; set; }
        public bool CharismaSave { get; set; }
    }
}
