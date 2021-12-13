using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.Shared.Game;

namespace WanderersDiary.CharacterManagement.Extensions
{
    public static class CharacterExtensions
    {
        public static CharacterClass ConcreteClass(this Character character, EClass characterClass)
        {
            return character.Classes.First(c => c.Class == characterClass);
        }
    }
}
