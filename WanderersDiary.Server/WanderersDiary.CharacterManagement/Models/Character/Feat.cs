using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Utility;
using WanderersDiary.Shared.Game.Enums;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Feat
    {
        public int Index { get; set; }

        public LocalizedString Description { get; set; }

        public ESource Source { get; set; }

        public int HitPointsFactor { get; set; }

        //Maybe other factors: AC, Speed
    }
}
