using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WanderersDiary.CharacterManagement.Extensions;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Utility;
using WanderersDiary.Shared.Game;
using WanderersDiary.Shared.Game.Enums;

namespace WanderersDiary.CharacterManagement.Classes
{
    public class Bard : ClassBase
    {
        public override LocalizedString Name => new LocalizedString { EN = "Bard", RU = "Бард" };

        public override EClass AccosiatedEClass => EClass.Bard;

        public override ESource Source => ESource.PHB;

        public override EDice HitDice => EDice.D8;

        public override List<ClassFeatures> Features => BardFeatures.Features;

        public override List<ArchetypeFeatures> ArchetypeFeatures => BardFeatures.ArchetypeFeatures;

        public override int AvailiableNumberOfSkills => 3;

        //All skills!
        public override List<ESkill> AvailiableSkills => new List<ESkill> { 
            ESkill.Athletics,       ESkill.Acrobatics,      ESkill.SleightOfHand,   ESkill.Stealth,         ESkill.Arcana,      ESkill.History,         
            ESkill.Investigation,   ESkill.Nature,          ESkill.Religion,        ESkill.AnimalHandling,  ESkill.Insight,     ESkill.Medicine,        
            ESkill.Perception,      ESkill.Survival,        ESkill.Deception,       ESkill.Intimidation,    ESkill.Performance, ESkill.Persuasion 
        };

        public override List<int> AttributesImprovementLevels => new List<int> { 4, 8, 12, 16, 19 };

        public override List<ClassSpellSlots> SpellSlots => new List<ClassSpellSlots>
        {
            //----------------------1--2--3--4--5--6--7--8--9
            new ClassSpellSlots(1,  2),
            new ClassSpellSlots(2,  3),
            new ClassSpellSlots(3,  4, 2),
            new ClassSpellSlots(4,  4, 3),
            new ClassSpellSlots(5,  4, 3, 2),
            new ClassSpellSlots(6,  4, 3, 3),
            new ClassSpellSlots(7,  4, 3, 3, 1),
            new ClassSpellSlots(8,  4, 3, 3, 2),
            new ClassSpellSlots(9,  4, 3, 3, 3, 1),
            new ClassSpellSlots(10, 4, 3, 3, 3, 2),

            //----------------------1--2--3--4--5--6--7--8--9
            new ClassSpellSlots(11, 4, 3, 3, 3, 2, 1),
            new ClassSpellSlots(12, 4, 3, 3, 3, 2, 1),
            new ClassSpellSlots(13, 4, 3, 3, 3, 2, 1, 1),
            new ClassSpellSlots(14, 4, 3, 3, 3, 2, 1, 1),
            new ClassSpellSlots(15, 4, 3, 3, 3, 2, 1, 1, 1),
            new ClassSpellSlots(16, 4, 3, 3, 3, 2, 1, 1, 1),
            new ClassSpellSlots(17, 4, 3, 3, 3, 2, 1, 1, 1, 1),
            new ClassSpellSlots(18, 4, 3, 3, 3, 2, 1, 1, 1, 1),
            new ClassSpellSlots(19, 4, 3, 3, 3, 2, 2, 1, 1, 1),
            new ClassSpellSlots(20, 4, 3, 3, 3, 2, 2, 2, 1, 1),
        };

        public override int LevelToGainArchetype => 3;

        public override LocalizedString ArchetypeCrunchName => new LocalizedString { EN = "College", RU = "Коллегия" };

        public override List<Archetype> AvailiableArchetypes => new List<Archetype> {
            new Archetype { Index = 1, Name = new LocalizedString { EN = "College of Valor", RU = "Коллегия Доблести" }, Source = ESource.PHB },
            new Archetype { Index = 2, Name = new LocalizedString { EN = "College of Lore", RU = "Коллегия Знаний" }, Source = ESource.PHB },
        };

        public override void HandleSpecificClassFeatures(Character character, int targetLevel)
        {
            if (targetLevel >= 2) UpdateJackOfAllTradesSkills(character);
            if (targetLevel == 3) AddExpertise(character);
            if (targetLevel == 5) AddInspirationShortRestReset(character);
        }

        private void UpdateJackOfAllTradesSkills(Character character)
        {
            IEnumerable<ESkill> allSkills = Enum.GetValues(typeof(ESkill)).Cast<ESkill>();
            IEnumerable<ESkill> missingSkills = allSkills.Where(s => !character.Skills.Any(cs => cs.Skill == s));
            IEnumerable<SkillProficiency> skillsToAdd = missingSkills.Select(s =>
                new SkillProficiency { Skill = s, Proficiency = EProficiency.JackOfAllTrades }
            );

            character.Skills.AddRange(skillsToAdd);
        }

        private void AddExpertise(Character character)
        {
            List<SkillProficiency> expertiseSkillsToChoose = character.Skills
                .Where(s => s.Proficiency == EProficiency.Proficient)
                .Select(s => new SkillProficiency { Skill = s.Skill, Proficiency = EProficiency.Expert })
                .ToList(); ;

            character.SkillsToChoose.Enqueue(new SkillsToChoose
            {
                AvailiableSkills = expertiseSkillsToChoose,
                AvailiableNumberOfSkills = 2
            });
        }

        private void AddInspirationShortRestReset(Character character)
        {
            Feature inspirationFeature = character
                .ConcreteClass(AccosiatedEClass)
                .Features
                .FirstOrDefault(s => s.Index == 2);

            inspirationFeature.ResetAfter = ERest.Short;
        }
    }
}
