﻿using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.Entities.Character;
using WanderersDiary.Entities.Models;

namespace WanderersDiary.Entities
{
    public class CharacterClass : EntityBase
    {
        public int Level { get; set; }

        public Class Class { get; set; }
    }
}
