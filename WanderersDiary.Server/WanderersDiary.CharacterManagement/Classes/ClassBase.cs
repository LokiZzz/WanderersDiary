using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Extensions;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Enums;
using WanderersDiary.CharacterManagement.Models.Game;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Classes
{
    public abstract class ClassBase
    {
        public void AddLevel(Character character)
        {
            if (!character.HasClass(AccosiatedEClass))
            {
                character.Classes.Add(new CharacterClass { Class = AccosiatedEClass, Level = 0 });
                AddSkills(character);
                AddSavingThrows(character);
                character.Inventory.EquipmentToChoose = StartingEquipment;
            }

            CharacterClass charClass = character.ConcreteClass(AccosiatedEClass);
            int currentLevel = charClass.Level;
            int targetLevel = currentLevel + 1;
            charClass.Level = targetLevel;

            AddHitDice(character);
            AddAttributesImprovements(character, targetLevel);
            AddFeatures(character, targetLevel);
            HandleSpecificClassFeatures(character, targetLevel);
            SetSpellSlots(character, targetLevel);

            if (targetLevel >= LevelToGainArchetype)
            {
                charClass.ArchetypesToSelectFrom = AvailiableArchetypes;
            }

            if (charClass.Archetype != null)
            {
                AddArchetypeFeatures(character, targetLevel);
                HandleSpecificArchetypeFeatures(character, targetLevel);
            }
        }  

        public void SetArchetype(Character character, int archetypeIndex)
        {
            CharacterClass charClass = character.ConcreteClass(AccosiatedEClass);

            if (charClass.Archetype == null)
            {
                charClass.Archetype = AvailiableArchetypes.First(a => a.Index == archetypeIndex);
                AddArchetypeFeatures(character, LevelToGainArchetype);
            }
        }

        private void AddSkills(Character character)
        {
            List<SkillProficiency> availiableSkills = AvailiableSkills
                .Select(s => new SkillProficiency { Skill = s, Proficiency = EProficiency.Proficient })
                .ToList();

            character.SkillsToChoose.Enqueue(new SkillsToChoose { 
                AvailiableSkills = availiableSkills,
                AvailiableNumberOfSkills = this.AvailiableNumberOfSkills
            });
        }

        private void AddSavingThrows(Character character)
        {
            foreach(EAttribute st in SavingThrows)
            {
                switch(st)
                {
                    case EAttribute.Strenght:
                        character.Attributes.StrenghtSave = true;
                        break;
                    case EAttribute.Dexterity:
                        character.Attributes.DexteritySave = true;
                        break;
                    case EAttribute.Constitution:
                        character.Attributes.ConstitutionSave = true;
                        break;
                    case EAttribute.Intelligence:
                        character.Attributes.IntelligenceSave = true;
                        break;
                    case EAttribute.Wisdom:
                        character.Attributes.WisdomSave = true;
                        break;
                    case EAttribute.Charisma:
                        character.Attributes.CharismaSave = true;
                        break;
                }
            }
        }

        private void AddHitDice(Character character)
        {
            if (character.HitDices.Any(hd => hd.Type == HitDice))
            {
                character.HitDices.First(hd => hd.Type == HitDice).Max++;
            }
            else
            {
                character.HitDices.Add(new HitDice { Type = HitDice, Current = 1, Max = 1 });
            }
        }

        private void AddAttributesImprovements(Character character, int targetLevel)
        {
            if(AttributesImprovementLevels.Any(l => l == targetLevel))
            {
                character.Attributes.FreeImprovementPoints += 2;
            }
        }

        private void AddFeatures(Character character, int targetLevel)
        {
            List<Feature> features = Features.Where(f => f.LevelToGain == targetLevel).ToList();

            if (features.Any())
            {
                character.ConcreteClass(AccosiatedEClass).Features.AddRange(features);
                character.ConcreteClass(AccosiatedEClass).Features.ForEach(f => f.UpdateMaxUses(character));
            }
        }

        private void AddArchetypeFeatures(Character character, int targetLevel)
        {
            CharacterClass charClass = character.ConcreteClass(AccosiatedEClass);
            Archetype archetype = charClass.Archetype;
            ArchetypeFeatures archetypeFeatures = ArchetypeFeatures.First(f => f.ArchetypeIndex == archetype.Index);

            character.ConcreteClass(AccosiatedEClass).Features.AddRange(archetypeFeatures.Features);
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

        public abstract List<EAttribute> SavingThrows { get; }

        public abstract List<EquipmentToChoose> StartingEquipment { get; }

        public abstract DiceRoll StartingGold { get; }

        public abstract List<int> AttributesImprovementLevels { get; }

        public abstract List<Feature> Features { get; }

        public abstract int LevelToGainArchetype { get; }

        public abstract List<ArchetypeFeatures> ArchetypeFeatures { get; }

        public abstract LocalizedString ArchetypeCrunchName { get; }

        public abstract List<Archetype> AvailiableArchetypes { get; }

        public abstract List<ClassSpellSlots> SpellSlots { get; }

        protected abstract void HandleSpecificClassFeatures(Character character, int targetLevel);

        protected abstract void HandleSpecificArchetypeFeatures(Character character, int targetLevel);
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
