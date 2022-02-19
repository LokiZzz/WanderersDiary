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

            context.SetLevel(EClass.Bard, 5);

            foreach(SkillsToChoose groupOfSkills in context.Character.SkillsToChoose.ToList())
            {
                for (int i = groupOfSkills.AvailiableNumberOfSkills; i != 0; i--)
                {
                    context.ChooseSkill(groupOfSkills.AvailiableSkills.Skip(i).First());
                }
            }

            context.Character.Skills.ForEach(s => 
                Console.WriteLine($"{context.Character.Skills.IndexOf(s)}. {s.Skill.ToString("G")}: {s.Proficiency.ToString("G")}")
            );
            Console.ReadLine();
        }

        
    }
}
