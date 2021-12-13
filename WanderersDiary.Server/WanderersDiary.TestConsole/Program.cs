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

            character.Skills = new System.Collections.Generic.List<SkillProficiency>
            {
                new SkillProficiency { Skill = ESkill.Acrobatics, Proficiency = EProficiency.Proficient },
                new SkillProficiency { Skill = ESkill.Performance, Proficiency = EProficiency.Proficient },
                new SkillProficiency { Skill = ESkill.Persuasion, Proficiency = EProficiency.Proficient },
            };

            character.AddLevels(EClass.Bard, 2);
        }
    }
}
