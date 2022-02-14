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
            var countOfSkillsToChoose = context.Character.AvailiableNumberOfSkillsToChoose;
            var availiableSkills = context.Character.SkillsToChoose;
            context.ChooseSkill(ESkill.Performance);
            context.ChooseSkills(new List<ESkill> { ESkill.Acrobatics, ESkill.SleightOfHand });

            context.ClearChanges();
        }
    }
}
