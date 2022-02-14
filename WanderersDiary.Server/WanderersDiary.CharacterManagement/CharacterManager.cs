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
    public class CharacterManager
    {
        public Character Character { get; private set; }

        public Character ModifiedCharacter { get; private set; }

        public ManagingCharacterState State { get; private set; } = new ManagingCharacterState();

        public CharacterManager(Character character = null)
        {
            if(character == null)
            {
                Character = new Character()
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
                Character = character;
            }

            ModifiedCharacter = Character.Copy();
            State.ChangesState = ECharacterChangesState.Saved;
        }

        public void SetLevel(EClass eClass, int levelToSet)
        {
            ClassBase blClass = CharacterClassFactory.GetClass(eClass);
            blClass.SetLevel(ModifiedCharacter, levelToSet);
            CharacterClass characterClass = ModifiedCharacter.ConcreteClass(eClass);

            State.NeedToChooseArchetype = characterClass.Archetype == null && levelToSet >= blClass.LevelToGainArchetype;
            State.NeedToChooseFeatures = ModifiedCharacter.NeedToChooseFeatures();
            State.NeedToChooseSkills = ModifiedCharacter.AvailiableNumberOfSkillsToChoose > 0;
            State.NeedToImproveAttributes = ModifiedCharacter.Attributes.FreeImprovementPoints > 0;
        }

        public void ChooseSkill(SkillProficiency skillProf)
        {
            SkillProficiency skillProfToChoose = ModifiedCharacter.SkillsToChoose
                .FirstOrDefault(s => s.Skill == skillProf.Skill);

            if (skillProfToChoose != null && !ModifiedCharacter.Skills.Any(s => s.Skill == skillProf.Skill))
            {
                ModifiedCharacter.Skills.Add(skillProfToChoose);
                ModifiedCharacter.SkillsToChoose.Remove(skillProfToChoose);
                ModifiedCharacter.AvailiableNumberOfSkillsToChoose--;
                State.NeedToChooseSkills = ModifiedCharacter.AvailiableNumberOfSkillsToChoose > 0;
            }
        }

        public void ChooseAttributeImprovement(EAttribute attribute)
        {
            if(ModifiedCharacter.Attributes.FreeImprovementPoints > 0)
            {
                ModifiedCharacter.ImproveAttribute(attribute);
                ModifiedCharacter.Attributes.FreeImprovementPoints--;
                State.NeedToImproveAttributes = ModifiedCharacter.Attributes.FreeImprovementPoints > 0;
            }
        }

        public void ChooseFeat(Feat feat)
        {
            if (ModifiedCharacter.Attributes.FreeImprovementPoints >= 2)
            {
                ModifiedCharacter.Feats.Add(feat);
                ModifiedCharacter.Attributes.FreeImprovementPoints -= 2;
                State.NeedToImproveAttributes = ModifiedCharacter.Attributes.FreeImprovementPoints > 0;
            }
        }

        public void ChooseClassFeature(EClass featureClass, int featureIndex)
        {
            CharacterClass processingClass = ModifiedCharacter.ConcreteClass(featureClass);

            if (processingClass != null && processingClass.FeatureGroupsToSelectFrom.Any())
            {
                List<Feature> group = processingClass.FeatureGroupsToSelectFrom
                    .FirstOrDefault(fg => fg.Any(f => f.Index == featureIndex));

                if(group != null)
                {
                    processingClass.Features.Add(group.FirstOrDefault(f => f.Index == featureIndex));
                    processingClass.FeatureGroupsToSelectFrom.Remove(group);
                    State.NeedToChooseFeatures = ModifiedCharacter.NeedToChooseFeatures();
                }
            }
        }

        public void ChooseArchetype(EClass eClass, int archetypeIndex)
        {
            CharacterClass characterClass = Character.ConcreteClass(eClass);

            if (characterClass != null)
            {
                ClassBase blClass = CharacterClassFactory.GetClass(eClass);
                blClass.SetArchetype(ModifiedCharacter, archetypeIndex);
                characterClass.ArchetypesToSelectFrom.Clear();
                State.NeedToChooseArchetype = false;
            }
        }

        public void Save()
        {
            Character = ModifiedCharacter.Copy();
            State.ChangesState = ECharacterChangesState.Saved;
        }

        public void ClearChanges()
        {
            ModifiedCharacter = Character.Copy();
            State.ChangesState = ECharacterChangesState.Saved;
        }
    }

    public class ManagingCharacterState
    {
        public ECharacterChangesState ChangesState { get; set; } = ECharacterChangesState.NotInitialized;

        public bool NeedToChooseFeatures { get; set; }

        public bool NeedToChooseArchetype { get; set; }

        public bool NeedToChooseSkills { get; set; }

        public bool NeedToImproveAttributes { get; set; }
    }

    public enum ECharacterChangesState
    {
        NotInitialized = 0,
        Saved = 1,
        Modified = 2,
    }
}
