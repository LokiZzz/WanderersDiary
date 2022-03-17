using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Static;

namespace WanderersDiary.CharacterManagement
{
    public static class CharacterSeed
    {
        public static Character GetNewCharacter()
        {
            Character newCharacter = new Character()
            {
                Attributes = new Attributes
                {
                    Strenght = 8,
                    Dexterity = 8,
                    Constitution = 8,
                    Intelligence = 8,
                    Wisdom = 8,
                    Charisma = 8
                }
            };

            newCharacter.Inventory.Currency.AddRange(
                CurrencyCollection.GetAll().Select(c => c.Copy()).ToList()
            );

            return newCharacter;
        }
    }
}
