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
            Character character = CharacterManager.Create();

            character.SetLevel(EClass.Bard, 3);

            character.SpellSlots.Spend(1);
            character.SpellSlots.Spend(2);

            character.SetLevel(EClass.Bard, 5);
        }
    }
}
