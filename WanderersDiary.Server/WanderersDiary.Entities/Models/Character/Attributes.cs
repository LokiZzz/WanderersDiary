﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Entities.Models.Character
{
    public class Attributes : EntityBase
    {
        public int Strenght { get; set; }
        public bool StrenghtSave { get; set; }

        public int Dexterity { get; set; }
        public bool DexteritySave { get; set; }

        public int Constitution { get; set; }
        public bool ConstitutionSave { get; set; }

        public int Intelligence { get; set; }
        public bool IntelligenceSave { get; set; }

        public int Wisdom { get; set; }
        public bool WisdomSave { get; set; }

        public int Charisma { get; set; }
        public bool CharismaSave { get; set; }
    }
}
