using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Classes;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Enums;
using WanderersDiary.CharacterManagement.Models.Game;

namespace WanderersDiary.CharacterManagement
{
    public class CharacterContext
    {
        private Character SavedCharacter { get; set; }

        public Character Character { get; private set; }

        public CharacterContext(Character character = null)
        {
            if(character == null)
            {
                SavedCharacter = CharacterSeed.GetNewCharacter();
            }
            else
            {
                SavedCharacter = character;
            }

            Character = SavedCharacter.Copy();
        }

        public void AddLevel(EClass eClass)
        {
            if(!NeedToChooseOption)
            {
                CharacterClassFactory.GetClass(eClass).AddLevel(Character);
                UpdateMaxHitPoints();
            }
        }

        public void UpdateMaxHitPoints()
        {
            if (Character.Classes.Any())
            {
                List<ClassBase> classes = Character.Classes.Select(c => CharacterClassFactory.GetClass(c.Class)).ToList();
                ClassBase firstClass = classes.First();
                CharacterClass firstCharClass = Character.ConcreteClass(firstClass.AccosiatedEClass);
                int conModifier = Character.Attributes.Constitution.Modifier();

                //First class
                int firstLevelHP = firstClass.HitDice.Max() + conModifier;
                int firstClassHP = firstLevelHP + (firstCharClass.Level - 1) * (firstClass.HitDice.Average() + conModifier);

                //Other classes
                int otherClassesHP = 0;

                foreach(ClassBase charClass in classes.Skip(1))
                {
                    otherClassesHP += Character.ConcreteClass(charClass.AccosiatedEClass).Level
                        * (charClass.HitDice.Average() + conModifier);
                }

                //Other bonuses (Race, Classes features, Feats)
                int otherHitPointBonuses = 0;

                if (Character.Race != null)
                {
                    otherHitPointBonuses += Character.Race.HitPointsFactor * Character.Level();
                }
                if (Character.Feats.Any())
                {
                    otherHitPointBonuses += Character.Feats.Sum(f => f.HitPointsFactor) * Character.Level();
                }
                otherHitPointBonuses += Character.Classes.Sum(c => c.Level * c.HitPointsFactor);

                Character.HitPoints.Maximum = firstClassHP + otherClassesHP + otherHitPointBonuses;
            }
        }

        public void ChooseSkill(ESkill skill, EProficiency proficiency)
        {
            SkillProficiency skillToChoose = Character.SkillsToChoose
                .Peek()
                .AvailiableSkills
                .FirstOrDefault(s => s.Skill == skill && s.Proficiency == proficiency);

            if (skillToChoose != null)
            {
                SkillProficiency existingProficiency = Character.Skills.FirstOrDefault(s => s.Skill == skill);
                bool isProficientToExpertiseUpgrade = existingProficiency?.Proficiency == EProficiency.Proficient 
                    && skillToChoose.Proficiency == EProficiency.Expert;
                bool isJoATToProficientUpgrade = existingProficiency?.Proficiency == EProficiency.JackOfAllTrades
                    && skillToChoose.Proficiency == EProficiency.Proficient;
                bool canChoose = existingProficiency == null || isProficientToExpertiseUpgrade || isJoATToProficientUpgrade;

                if (canChoose)
                {
                    if(isProficientToExpertiseUpgrade || isJoATToProficientUpgrade)
                    {
                        Character.Skills.Remove(existingProficiency);
                    }

                    Character.Skills.Add(skillToChoose);
                    Character.SkillsToChoose.Peek().AvailiableSkills.RemoveAll(s => s.Skill == skillToChoose.Skill);
                    Character.SkillsToChoose.Peek().AvailiableNumberOfSkills--;

                    if(Character.SkillsToChoose.Peek().AvailiableNumberOfSkills == 0)
                    {
                        Character.SkillsToChoose.Dequeue();
                    }
                }
            }
        }

        public void ChooseSkills(Dictionary<ESkill, EProficiency> skills)
        {
            foreach(KeyValuePair<ESkill, EProficiency> skill in skills)
            {
                ChooseSkill(skill.Key, skill.Value);
            }
        }

        public void ChooseSkill(SkillProficiency skillProf) => ChooseSkill(skillProf.Skill, skillProf.Proficiency);

        public void ChooseSkills(List<SkillProficiency> skills) => skills.ForEach(s => ChooseSkill(s.Skill, s.Proficiency));

        public void ChooseAttributeImprovement(EAttribute attribute)
        {
            if(Character.Attributes.FreeImprovementPoints > 0)
            {
                Character.ImproveAttribute(attribute);
                Character.Attributes.FreeImprovementPoints--;
            }
        }

        public void ChooseFeat(Feat feat)
        {
            if (Character.Attributes.FreeImprovementPoints >= 2)
            {
                Character.Feats.Add(feat);
                Character.Attributes.FreeImprovementPoints -= 2;
                UpdateMaxHitPoints();
            }
        }

        public void ChooseClassFeature(EClass featureClass, int featureIndex)
        {
            CharacterClass processingClass = Character.ConcreteClass(featureClass);

            if (processingClass != null && processingClass.FeatureGroupsToSelectFrom.Any())
            {
                List<Feature> group = processingClass.FeatureGroupsToSelectFrom
                    .FirstOrDefault(fg => fg.Any(f => f.Index == featureIndex));

                if(group != null)
                {
                    processingClass.Features.Add(group.FirstOrDefault(f => f.Index == featureIndex));
                    processingClass.FeatureGroupsToSelectFrom.Remove(group);
                }
            }
        }

        public void ChooseClassFeatures(Dictionary<EClass, int> features)
        {
            foreach(KeyValuePair<EClass, int> feature in features)
            {
                ChooseClassFeature(feature.Key, feature.Value);
            }
        }

        public void ChooseArchetype(EClass eClass, int archetypeIndex)
        {
            CharacterClass characterClass = Character.ConcreteClass(eClass);

            if (characterClass != null)
            {
                ClassBase blClass = CharacterClassFactory.GetClass(eClass);
                blClass.SetArchetype(Character, archetypeIndex);
                characterClass.ArchetypesToSelectFrom.Clear();
            }
        }

        public DiceRoll SwitchStartingEquipmentToGold()
        {
            if (Character.Inventory.EquipmentToChoose.Any())
            {
                Character.Inventory.EquipmentToChoose.Clear();

                return CharacterClassFactory.GetClass(Character.Classes.First().Class).StartingGold;
            }
            else
            {
                return null;
            }
        }

        public void Save()
        {
            if (!NeedToChooseOption)
            {
                SavedCharacter = Character.Copy();
            }
        }

        public void ClearChanges()
        {
            Character = SavedCharacter.Copy();
        }

        public bool HasChanges => !SavedCharacter.Equals(Character);

        public bool NeedToChooseFeatures => Character.NeedToChooseFeatures();

        public bool NeedToChooseArchetype => GetNeedToChooseArchetype();

        public bool NeedToChooseSkills => Character.SkillsToChoose.Any();

        public bool NeedToImproveAttributes => Character.Attributes.FreeImprovementPoints > 0;

        private bool GetNeedToChooseArchetype()
        {
            bool needToChooseArchetype = false;

            foreach (CharacterClass charClass in Character.Classes)
            {
                ClassBase blClass = CharacterClassFactory.GetClass(charClass.Class);

                if (charClass.Archetype == null && charClass.Level >= blClass.LevelToGainArchetype)
                {
                    needToChooseArchetype = true;
                    break;
                }
            }

            return needToChooseArchetype;
        }

        public bool NeedToChooseOption => 
            NeedToChooseFeatures ||
            NeedToChooseArchetype ||
            NeedToChooseSkills ||
            NeedToImproveAttributes;
    }
}
