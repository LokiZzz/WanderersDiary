using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Enums;

namespace WanderersDiary.CharacterManagement.Models.Game
{
    public class DiceRoll
    {
        public DiceRoll(int count, EDice dice, int modifier = 0, int? coef = null)
        {
            Count = count;
            Dice = dice;
            Modifier = modifier;

            if (coef != null)
            {
                Сoefficient = coef.Value;
            }
        }

        public int Count { get; set; }

        public EDice Dice { get; set; }

        public int Modifier { get; set; }

        public int Сoefficient { get; set; } = 1;
    }
}
