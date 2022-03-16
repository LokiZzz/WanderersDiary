using System;
using System.Collections.Generic;
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

            CurrencyCollection.GetAll().ForEach(c =>
                newCharacter.Inventory.Currency.Add(c.Copy())
            );

            return newCharacter;
        }
    }
}
