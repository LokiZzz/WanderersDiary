using System;
using WanderersDiary.CharacterManagement;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.Shared.Game;

namespace WanderersDiary.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Character character = CharacterManager.Create();

            character.Attributes = new Attributes { Charisma = 6 };
            character.AddLevels(EClass.Bard, 1);

            character.Attributes = new Attributes { Charisma = 17 };
            character.AddLevels(EClass.Bard, 2);
        }
    }
}
