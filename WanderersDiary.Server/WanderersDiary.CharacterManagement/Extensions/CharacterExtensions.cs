using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.Shared.Game;

namespace WanderersDiary.CharacterManagement.Extensions
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
    }
}
