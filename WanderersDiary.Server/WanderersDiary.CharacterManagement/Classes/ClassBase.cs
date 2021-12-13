using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Extensions;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.Shared.Game;

namespace WanderersDiary.CharacterManagement.Classes
{
    public abstract class ClassBase
    {
        public void AddLevels(Character character, int targetLevel)
        {
            if (!character.Classes.Any(c => c.Class == AccosiatedEClass))
            {
                character.Classes.Add(new CharacterClass { Class = AccosiatedEClass, Archetype = 0, Level = 1 });
            }

            int currentLevel = character.ConcreteClass(AccosiatedEClass).Level;

            if (currentLevel < targetLevel)
            {
                character.ConcreteClass(AccosiatedEClass).Level = targetLevel;
                AddFeatures(character, currentLevel, targetLevel);

                character.ConcreteClass(AccosiatedEClass).Features.ForEach(f => f.UpdateMaxUses(character));

                HandleSpecificClassFeatures(character, targetLevel);
            }
        }

        private void AddFeatures(Character character, int fromLevel, int toLevel)
        {
            List<ClassLevelFeatures> levels = Features.Where(f => f.Level >= fromLevel && f.Level <= toLevel).ToList();

            foreach(ClassLevelFeatures level in levels)
            {
                character.ConcreteClass(AccosiatedEClass).Features.AddRange(level.Features);
            }
        }

        public abstract EClass AccosiatedEClass { get; }

        public abstract EDice HitDice { get; }

        public abstract int AvailiableNumberOfSkills { get; }

        public abstract List<ESkill> AvailiableSkills { get; }

        public abstract List<ClassLevelFeatures> Features { get; }

        public abstract void HandleSpecificClassFeatures(Character character, int targetLevel);
    }
}
