using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Game;

namespace WanderersDiary.CharacterManagement.Extensions
{
    public static class GameExtensions
    {
        public static int Roll(this DiceRoll diceRoll, out List<int> rollResults)
        {
            rollResults = new List<int>();

            for (int rolls = 0; rolls < diceRoll.Count; rolls++)
            {
                rollResults.Add(new Random().Next(1, (int)diceRoll.Dice));
            }

            return (rollResults.Sum() + diceRoll.Modifier) * diceRoll.Сoefficient;
        }

        public static int Roll(this DiceRoll diceRoll) => diceRoll.Roll(out _);
    }
}
