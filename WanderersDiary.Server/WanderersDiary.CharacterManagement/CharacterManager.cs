using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Classes;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.Shared.Game;

namespace WanderersDiary.CharacterManagement
{
    public static class CharacterManager
    {
        public static Character Create()
        {
            return new Character();
        }

        public static void AddLevels(this Character character, EClass characterClass, int levels)
        {
            switch(characterClass)
            {
                case EClass.Bard:
                    Bard.AddLevel(character, levels);
                    break;
            }
        }
    }
}
