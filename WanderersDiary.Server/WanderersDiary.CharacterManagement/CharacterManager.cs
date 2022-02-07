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

        public ECharacterState State { get; private set; } = ECharacterState.NotInitialized;

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
            State = ECharacterState.Saved;
        }

        public void SetLevel(EClass characterClass, int level)
        {
            CharacterClassFactory.GetClass(characterClass).SetLevel(ModifiedCharacter, level);

            State = ModifiedCharacter.NeedToChooseFeatures() 
                ? ECharacterState.NeedToChooseFeatures 
                : ECharacterState.Modified;
        }

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
                    }
                }
            }

            if(!ModifiedCharacter.NeedToChooseFeatures())
            {
                State = ECharacterState.Modified;
            }
        }

        private Character GetNewCharacter()
        {
            return ;
        }

        public void Save()
        {
            Character = ModifiedCharacter.Copy();
            State = ECharacterState.Saved;
        }

        public void ClearChanges()
        {
            ModifiedCharacter = Character.Copy();
            State = ECharacterState.Saved;
        }
    }

    public enum ECharacterState
    {
        NotInitialized = 1,
        Saved = 2,
        Modified = 3,
        NeedToChooseFeatures = 4
    }
}
