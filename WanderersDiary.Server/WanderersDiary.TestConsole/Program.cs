using System;
using System.Linq;
using WanderersDiary.CharacterManagement;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.Shared.Game;
using WanderersDiary.CharacterManagement.Extensions;

namespace WanderersDiary.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CharacterContext context = new CharacterContext();

            Character character = context.Character;
            character.Attributes.Strenght = 15;
            character.Attributes.Constitution = 17;
            character.Attributes.StrenghtSave = true;

            bool hasChanges = context.HasChanges;

            context.Save();

            hasChanges = context.HasChanges;
        }
    }
}
