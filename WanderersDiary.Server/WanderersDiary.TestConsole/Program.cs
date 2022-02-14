using System;
using System.Linq;
using WanderersDiary.CharacterManagement;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.Shared.Game;
using WanderersDiary.CharacterManagement.Extensions;
using System.Collections.Generic;

namespace WanderersDiary.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CharacterContext context = new CharacterContext();

            context.Character.Attributes.Strenght = 15;

            context.SetLevel(EClass.Bard, 1);
            context.ChooseSkills(new List<ESkill> { ESkill.Performance, ESkill.Acrobatics, ESkill.SleightOfHand });

            context.SetLevel(EClass.Bard, 4);
            var archetypes = context.Character.ConcreteClass(EClass.Bard).ArchetypesToSelectFrom;
            context.ChooseArchetype(EClass.Bard, archetypes.First().Index);

            bool hasChanges = context.HasChanges;

            context.ClearChanges();
        }
    }
}
