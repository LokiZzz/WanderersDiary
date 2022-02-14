using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Extensions;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Utility;
using WanderersDiary.Shared.Game;
using WanderersDiary.Shared.Game.Enums;

namespace WanderersDiary.CharacterManagement.Classes
{
    public abstract class ClassBase
    {
        public void SetLevel(Character character, int targetLevel)
        {
            if (!character.HasClass(AccosiatedEClass))
            {
                character.Classes.Add(new CharacterClass { Class = AccosiatedEClass, Level = 0 });
                AddSkills(character);
            }

            CharacterClass charClass = character.ConcreteClass(AccosiatedEClass);
            int currentLevel = charClass.Level;

            if (currentLevel < targetLevel)
            {
                charClass.Level = targetLevel;
                AddAttributesImprovements(character, targetLevel, currentLevel);
                AddFeatures(character, currentLevel, targetLevel);

                if (targetLevel >= LevelToGainArchetype)
                {
                    charClass.ArchetypesToSelectFrom = AvailiableArchetypes;
                }

                if (charClass.Archetype != null)
                {
                    AddArchetypeFeatures(character, currentLevel, targetLevel);
                }

                SetSpellSlots(character, targetLevel);
                HandleSpecificClassFeatures(character, targetLevel);
            }
        }

        public void SetArchetype(Character character, int archetypeIndex)
        {
            CharacterClass charClass = character.ConcreteClass(AccosiatedEClass);

            if (charClass.Archetype == null)
            {
                charClass.Archetype = AvailiableArchetypes.First(a => a.Index == archetypeIndex);
                AddArchetypeFeatures(character, fromLevel: LevelToGainArchetype - 1, toLevel: charClass.Level);
            }
        }

        private void AddSkills(Character character)
        {
            character.SkillsToChoose = AvailiableSkills
                .Select(s => new SkillProficiency { Skill = s, Proficiency = EProficiency.Proficient })
                .Where(s => !character.SkillsToChoose.Any(stc => stc.Skill == s.Skill))
                .ToList();
            character.AvailiableNumberOfSkillsToChoose = AvailiableNumberOfSkills;
        }

        private void AddAttributesImprovements(Character character, int targetLevel, int currentLevel)
        {
            int improvementCount = AttributesImprovementLevels.Count(l => l >= currentLevel && l <= targetLevel);
            character.Attributes.FreeImprovementPoints += improvementCount * 2;
        }

        private void AddFeatures(Character character, int fromLevel, int toLevel)
        {
            List<ClassFeatures> levels = Features.Where(f => f.Level > fromLevel && f.Level <= toLevel).ToList();

            foreach (ClassFeatures level in levels)
            {
                character.ConcreteClass(AccosiatedEClass).Features.AddRange(level.Features);
            }

            character.ConcreteClass(AccosiatedEClass).Features.ForEach(f => f.UpdateMaxUses(character));
        }

        private void AddArchetypeFeatures(Character character, int fromLevel, int toLevel)
        {
            CharacterClass charClass = character.ConcreteClass(AccosiatedEClass);
            Archetype archetype = charClass.Archetype;
            List<ArchetypeFeatures> levels = ArchetypeFeatures.Where(f => 
                f.Level > fromLevel && 
                f.Level <= toLevel &&
                f.Archetype.Index == archetype.Index)
                .ToList();

            foreach (ArchetypeFeatures level in levels)
            {
                character.ConcreteClass(AccosiatedEClass).Features.AddRange(level.Features);
            }

            character.ConcreteClass(AccosiatedEClass).Features.ForEach(f => f.UpdateMaxUses(character));
        }

        private void SetSpellSlots(Character character, int targetLevel)
        {
            ClassSpellSlots targetLevelSpellSlots = SpellSlots.First(f => f.Level == targetLevel);

            foreach (SpellSlot spellSlotToSet in targetLevelSpellSlots.SpellSlotSet)
            {
                SpellSlot spellSlot = character.SpellSlots.FirstOrDefault(s => s.Level == spellSlotToSet.Level);

                if (spellSlot == null)
                {
                    character.SpellSlots.Add(spellSlotToSet);
                }
                else
                {
                    spellSlot.Max = spellSlotToSet.Max;
                }
            }
        }

        public abstract LocalizedString Name { get; }

        public abstract ESource Source { get; }

        public abstract EClass AccosiatedEClass { get; }

        public abstract EDice HitDice { get; }

        public abstract int AvailiableNumberOfSkills { get; }

        public abstract List<ESkill> AvailiableSkills { get; }

        public abstract List<int> AttributesImprovementLevels { get; }

        public abstract List<ClassFeatures> Features { get; }

        public abstract int LevelToGainArchetype { get; }

        public abstract List<ArchetypeFeatures> ArchetypeFeatures { get; }

        public abstract LocalizedString ArchetypeCrunchName { get; }

        public abstract List<Archetype> AvailiableArchetypes { get; }

        public abstract List<ClassSpellSlots> SpellSlots { get; }

        public abstract void HandleSpecificClassFeatures(Character character, int targetLevel);
    }

    public class ClassFeatures
    {
        public int Level { get; set; }

        public List<Feature> Features { get; set; }
    } 

    public class ClassSpellSlots
    {
        public ClassSpellSlots(int characterLevel, params int[] slotsCount)
        {
            Level = characterLevel;
            SpellSlotSet = new List<SpellSlot>();

            int slotLevel = 1;
            foreach(int count in slotsCount)
            {
                SpellSlotSet.Add(new SpellSlot(slotLevel, count));
                slotLevel++;
            }
        }

        public int Level { get; set; }

        public List<SpellSlot> SpellSlotSet { get; set; }
    }
}
