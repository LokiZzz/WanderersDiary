using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.Shared.Game;

namespace WanderersDiary.CharacterManagement.Classes
{
    public class Bard
    {
        public void AddLevel(Character character)
        {
            if(!character.Classes.Any(c => c.Class == EClass.Bard))
            {
                character.Classes.Add(new CharacterClass { Class = EClass.Bard, Archetype = 0, Level = 1 });
            }

            AddFeatures(character);
        }

        private void AddFeatures(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
