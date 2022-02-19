using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Classes;
using WanderersDiary.CharacterManagement.Extensions;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.Shared.Game;
using WanderersDiary.Shared.Game.Enums;

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
                SavedCharacter = new Character()
                {
                    Attributes = new Attributes
                    {
                        Strenght = 8,
                        Dexterity = 8,
                        Constitution = 8,
                        Intelligence = 8,
                        Wisdom = 8,
                        Charisma = 8
                    }
                };
            }
            else
            {
                SavedCharacter = character;
            }

            Character = SavedCharacter.Copy();
        }

        public void SetLevel(EClass eClass, int levelToSet)
        {
            CharacterClassFactory.GetClass(eClass).SetLevel(Character, levelToSet);
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

        public void Save()
        {
            if (CanSave)
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

        public bool CanSave => !NeedToChooseFeatures &&
            !NeedToChooseArchetype &&
            !NeedToChooseSkills &&
            !NeedToImproveAttributes;
    }
}
