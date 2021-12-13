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
            Character initialCharacter = new Character();
            initialCharacter.Attributes = new Attributes
            {
                Strenght = 8, Dexterity = 8, Constitution = 8,
                Intelligence = 8, Wisdom = 8, Charisma = 8
            };

            return initialCharacter;
        }

        public static void AddLevels(this Character character, EClass characterClass, int levels)
        {
            switch(characterClass)
            {
                case EClass.Bard:
                    new Bard().AddLevels(character, levels);
                    break;
            }
        }
    }
}
