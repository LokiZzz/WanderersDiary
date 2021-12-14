using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Extensions;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.Shared.Game;

namespace WanderersDiary.CharacterManagement.Classes
{
    public abstract class ClassBase
    {
        public void AddLevels(Character character, int targetLevel)
        {
            if (!character.Classes.Any(c => c.Class == AccosiatedEClass))
            {
                character.Classes.Add(new CharacterClass { Class = AccosiatedEClass, Archetype = 0, Level = 1 });
            }

            int currentLevel = character.ConcreteClass(AccosiatedEClass).Level;

            if (currentLevel < targetLevel)
            {
                character.ConcreteClass(AccosiatedEClass).Level = targetLevel;

                AddFeatures(character, currentLevel, targetLevel);
                character.ConcreteClass(AccosiatedEClass).Features.ForEach(f => f.UpdateMaxUses(character));

                SetSpellSlots(character, targetLevel);

                HandleSpecificClassFeatures(character, targetLevel);
            }
        }

        private void AddFeatures(Character character, int fromLevel, int toLevel)
        {
            List<ClassFeatures> levels = Features.Where(f => f.Level >= fromLevel && f.Level <= toLevel).ToList();

            foreach(ClassFeatures level in levels)
            {
                character.ConcreteClass(AccosiatedEClass).Features.AddRange(level.Features);
            }
        }

        private void SetSpellSlots(Character character, int targetLevel)
        {
            ClassSpellSlots targetLevelSpellSlots = SpellSlots.First(f => f.Level == targetLevel);

            foreach(SpellSlot spellSlotToSet in targetLevelSpellSlots.SpellSlotSet)
            {
                SpellSlot spellSlot = character.SpellSlots.FirstOrDefault(s => s.Level == spellSlotToSet.Level);

                if(spellSlot == null)
                {
                    character.SpellSlots.Add(spellSlotToSet);
                }
                else
                {
                    spellSlot.Max = spellSlotToSet.Max;
                }
            }
        }

        public abstract EClass AccosiatedEClass { get; }

        public abstract EDice HitDice { get; }

        public abstract int AvailiableNumberOfSkills { get; }

        public abstract List<ESkill> AvailiableSkills { get; }

        public abstract List<ClassFeatures> Features { get; }

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
