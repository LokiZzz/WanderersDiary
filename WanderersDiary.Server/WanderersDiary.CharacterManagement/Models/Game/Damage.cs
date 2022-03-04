using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Enums;

namespace WanderersDiary.CharacterManagement.Models.Game
{
    public class Damage
    {
        public EDamageType Type { get; set; }

        public int DiceCount { get; set; }

        public EDice DiceType { get; set; }

        public int Modifier { get; set; }
    }
}
