using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Classes;
using WanderersDiary.CharacterManagement.Extensions;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.Shared.Game;

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
            CharacterClass characterClass = Character.ConcreteClass(eClass);

            State.NeedToChooseArchetype = characterClass.Archetype == null && levelToSet >= blClass.LevelToGainArchetype;
            State.NeedToChooseFeatures = ModifiedCharacter.NeedToChooseFeatures();
        }

        //ChooseSkill

        //ChooseAttributeImprovement

        //ChooseFeat

        public void ChooseFeatures(params Feature[] features)
        {
            foreach(Feature feature in features)
            {
                ChooseFeature(feature);
            }
        }

        public void ChooseFeature(Feature feature)
        {
            foreach(CharacterClass characterClass in ModifiedCharacter.Classes)
            {
                foreach(List<Feature> groupToSelectFrom in characterClass.FeatureGroupsToSelectFrom.ToList())
                {
                    if(groupToSelectFrom.Contains(feature))
                    {
                        characterClass.Features.Add(feature);
                        characterClass.FeatureGroupsToSelectFrom.Remove(groupToSelectFrom);
                        State.NeedToChooseFeatures = ModifiedCharacter.NeedToChooseFeatures();

                        return;
                    }
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
    }

    public enum ECharacterChangesState
    {
        NotInitialized = 0,
        Saved = 1,
        Modified = 2,
    }
}
