using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WanderersDiary.CharacterManagement.Extensions;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Enums;
using WanderersDiary.CharacterManagement.Models.Game;
using WanderersDiary.CharacterManagement.Models.Utility;
using WanderersDiary.CharacterManagement.Static;

namespace WanderersDiary.CharacterManagement.Classes
{
    public class Bard : ClassBase
    {
        public override LocalizedString Name => new LocalizedString { EN = "Bard", RU = "Бард" };

        public override EClass AccosiatedEClass => EClass.Bard;

        public override ESource Source => ESource.PHB;

        public override EDice HitDice => EDice.D8;

        public override List<Feature> Features => BardFeatures.Features;

        public override List<ArchetypeFeatures> ArchetypeFeatures => BardFeatures.ArchetypeFeatures;

        public override int AvailiableNumberOfSkills => 3;

        //All skills!
        public override List<ESkill> AvailiableSkills => new List<ESkill> {
            ESkill.Athletics,       ESkill.Acrobatics,      ESkill.SleightOfHand,   ESkill.Stealth,         ESkill.Arcana,      ESkill.History,
            ESkill.Investigation,   ESkill.Nature,          ESkill.Religion,        ESkill.AnimalHandling,  ESkill.Insight,     ESkill.Medicine,
            ESkill.Perception,      ESkill.Survival,        ESkill.Deception,       ESkill.Intimidation,    ESkill.Performance, ESkill.Persuasion
        };

        public override List<EAttribute> SavingThrows => new List<EAttribute> { EAttribute.Dexterity, EAttribute.Charisma };

        public override List<EquipmentToChoose> StartingEquipment => new List<EquipmentToChoose>
        {
            new EquipmentToChoose { GroupToChooseFrom = {
                new EquipmentToChoose(WeaponCollection.Rapier), new EquipmentToChoose(WeaponCollection.Longsword),
                new EquipmentToChoose(WeaponCollection.GetAll().Where(w => w.Categories.Contains(EWeaponType.Simple)).Select(w => (Equipment)w).ToList())
            }},
            new EquipmentToChoose { GroupToChooseFrom = {
                new EquipmentToChoose(PackCollection.DiplomatsPack), new EquipmentToChoose(PackCollection.EntertainersPack)
            }},
            new EquipmentToChoose { GroupToChooseFrom = {
                new EquipmentToChoose(ToolsCollection.Bagpipes), new EquipmentToChoose(ToolsCollection.Drum), new EquipmentToChoose(ToolsCollection.Dulcimer),
                new EquipmentToChoose(ToolsCollection.Flute), new EquipmentToChoose(ToolsCollection.Lute), new EquipmentToChoose(ToolsCollection.Lyre),
                new EquipmentToChoose(ToolsCollection.Horn), new EquipmentToChoose(ToolsCollection.PanFlute), new EquipmentToChoose(ToolsCollection.Shawn),
                new EquipmentToChoose(ToolsCollection.Viol)
            }},
            new EquipmentToChoose { GroupToChooseFrom = {
                new EquipmentToChoose(WeaponCollection.Dagger, ArmorCollection.Leather)
            }},
        };

        public override DiceRoll StartingGold => new DiceRoll(5, EDice.D4, coef: 10);

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
            new Archetype { Index = (int)EBardArchetypes.Valor, Name = new LocalizedString { EN = "College of Valor", RU = "Коллегия Доблести" }, Source = ESource.PHB },
            new Archetype { Index = (int)EBardArchetypes.Lore, Name = new LocalizedString { EN = "College of Lore", RU = "Коллегия Знаний" }, Source = ESource.PHB },
        };

        protected override void HandleSpecificClassFeatures(Character character, int targetLevel)
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

        protected override void HandleSpecificArchetypeFeatures(Character character, int targetLevel)
        {
            if(character.ConcreteClass(AccosiatedEClass).Archetype.Index == (int)EBardArchetypes.Valor)
            {
                if (targetLevel == 3) AddValorProficiencies(character);
            }
            if (character.ConcreteClass(AccosiatedEClass).Archetype.Index == (int)EBardArchetypes.Lore)
            {
                if (targetLevel == 3) AddLoreProficiencies(character);
            }
        }

        private void AddValorProficiencies(Character character)
        {
            character.ArmouryProficiencies.MediumArmor = true;
            character.ArmouryProficiencies.Shields = true;
            character.ArmouryProficiencies.MartialWeapons = true;
        }

        private void AddLoreProficiencies(Character character)
        {
            IEnumerable<ESkill> allSkills = Enum.GetValues(typeof(ESkill)).Cast<ESkill>();
            IEnumerable<ESkill> missingSkills = allSkills.Where(s => !character.Skills.Any(cs => cs.Skill == s));

            character.SkillsToChoose.Enqueue(new SkillsToChoose 
            { 
                AvailiableNumberOfSkills = 3, 
                AvailiableSkills = missingSkills.Select(s => new SkillProficiency 
                { 
                    Skill = s, 
                    Proficiency = EProficiency.Proficient 
                }).ToList() 
            });
        }
    }

    public enum EBardArchetypes
    {
        Valor = 1,      //Player's Handbook
        Lore = 2,       //Player's Handbook
        Glamour = 3,    //Xanathar's Guide to Everything
        Swords = 4,     //Xanathar's Guide to Everything
        Whispers = 5,   //Xanathar's Guide to Everything
        Creation = 6,   //Tasha's Cauldron of Everything
        Eloquence = 7,  //Tasha's Cauldron of Everything
        Spirits = 8,    //Van Richten's Guide to Ravenloft
    }
}
