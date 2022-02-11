﻿using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Utility;
using WanderersDiary.Shared.Game.Enums;

namespace WanderersDiary.CharacterManagement.Classes
{
    public class Archetype
    {
        public int Index { get; set; }

        public LocalizedString Name { get; set; }

        public ESource Source { get; set; }
    }

    public class ArchetypeFeatures : ClassFeatures
    {
        public Archetype Archetype { get; set; }
    }
}