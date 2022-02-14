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

        public void ChooseSkill(SkillProficiency skillProf)
        {
            SkillProficiency skillProfToChoose = Character.SkillsToChoose
                .FirstOrDefault(s => s.Skill == skillProf.Skill);

            if (skillProfToChoose != null && !Character.Skills.Any(s => s.Skill == skillProf.Skill))
            {
                Character.Skills.Add(skillProfToChoose);
                Character.SkillsToChoose.Remove(skillProfToChoose);
                Character.AvailiableNumberOfSkillsToChoose--;
            }
        }

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

        public void ChooseArchetype(EClass eClass, int archetypeIndex)
        {
            CharacterClass characterClass = SavedCharacter.ConcreteClass(eClass);

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

        public bool NeedToChooseArchetype => GetNeedToChooseSkills();

        public bool NeedToChooseSkills => Character.AvailiableNumberOfSkillsToChoose > 0;

        public bool NeedToImproveAttributes => Character.Attributes.FreeImprovementPoints > 0;

        private bool GetNeedToChooseSkills()
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
