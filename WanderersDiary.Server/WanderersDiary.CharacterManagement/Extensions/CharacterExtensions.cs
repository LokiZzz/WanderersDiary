using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Classes;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Enums;

namespace WanderersDiary.CharacterManagement
{
    public static class CharacterExtensions
    {
        public static CharacterClass ConcreteClass(this Character character, EClass characterClass)
        {
            return character.Classes.FirstOrDefault(c => c.Class == characterClass);
        }

        public static bool HasClass(this Character character, EClass characterClass)
        {
            return character.Classes.Any(c => c.Class == characterClass);
        }

        public static int Level(this Character character)
        {
            return character.Classes.Sum(c => c.Level);
        }

        public static bool NeedToChooseFeatures(this Character character)
        {
            return character.Classes.Any(c => c.FeatureGroupsToSelectFrom.Any());
        }

        public static void Spend(this List<SpellSlot> spellSlots, int slotLevel)
        {
            SpellSlot slot = spellSlots.FirstOrDefault(ss => ss.Level == slotLevel);

            if(slot != null && slot.Spent < slot.Max)
            {
                slot.Spent++;
            }
        }

        public static Archetype Get(this List<Archetype> archetypesToSelectFrom, int index)
        {
            return archetypesToSelectFrom.FirstOrDefault(a => a.Index == index);
        }

        public static void ImproveAttribute(this Character character, EAttribute attributeToImprove)
        {
            switch(attributeToImprove)
            {
                case EAttribute.Strenght:
                    character.Attributes.Strenght++;
                    break;
                case EAttribute.Dexterity:
                    character.Attributes.Dexterity++;
                    break;
                case EAttribute.Constitution:
                    character.Attributes.Constitution++;
                    break;
                case EAttribute.Intelligence:
                    character.Attributes.Intelligence++;
                    break;
                case EAttribute.Wisdom:
                    character.Attributes.Wisdom++;
                    break;
                case EAttribute.Charisma:
                    character.Attributes.Charisma++;
                    break;
            }
        }
    }
}
