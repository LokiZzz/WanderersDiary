using System;
using System.Linq;
using WanderersDiary.CharacterManagement;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Enums;

namespace WanderersDiary.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CharacterContext context = new CharacterContext();

            context.Character.Attributes.Constitution = 15;

            context.Character.Race = new CharacterRace { Race = ERace.Elf, HitPointsFactor = 2 };

            context.AddLevel(EClass.Bard);
            context.AddLevel(EClass.Bard);
            context.AddLevel(EClass.Bard);
            context.AddLevel(EClass.Bard);

            Feat feat = new Feat { HitPointsFactor = 2 };
            context.ChooseFeat(feat);

            Console.WriteLine(context.Character.HitPoints.Maximum);

            Console.ReadLine();
        }
    }
}
