using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WanderersDiary.CharacterManagement.Extensions;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.Shared.Game;

namespace WanderersDiary.CharacterManagement.Classes
{
    public class Bard
    {
        public static void AddLevel(Character character, int levelToAdd)
        {
            if (!character.Classes.Any(c => c.Class == AccosiatedEClass))
            {
                character.Classes.Add(new CharacterClass { Class = AccosiatedEClass, Archetype = 0, Level = 1 });
                AddFeatures(character, 1, 1);
            }

            CharacterClass characterClass = character.Classes.First(c => c.Class == AccosiatedEClass);
            characterClass.Features.ForEach(f => f.UpdateMaxUses(character));

            //Initialize or update max and current uses for features. Use GetMaxUses delegate.
        }

        private static void AddFeatures(Character character, int fromLevel, int toLevel)
        {
            CharacterClass characterClass = character.Classes.First(c => c.Class == AccosiatedEClass);

            List<LevelClassFeatures> levels = Features.Where(f => f.Level >= fromLevel && f.Level <= toLevel).ToList();

            foreach(LevelClassFeatures level in levels)
            {
                characterClass.Features.AddRange(level.Features);
            }

        }

        public static EClass AccosiatedEClass => EClass.Bard;
        public static EDice HitDice => EDice.D8;

        public static List<LevelClassFeatures> Features => new List<LevelClassFeatures>
        {
            new LevelClassFeatures { Level = 1, Features = new List<Feature>
            {
                new Feature
                {
                    LevelToGain = 1, Name_RU = "Использование заклинаний", Name_EN = "Spellcasting",
                    Description_RU = "Вы восстанавливаете все потраченные ячейки в конце продолжительного отдыха. Вы используете Харизму в случаях, когда заклинание ссылается на базовую характеристику. Сл спасброска = 8 + ваш бонус мастерства + ваш модификатор Харизмы. Модификатор броска атаки = ваш бонус мастерства + ваш модификатор Харизмы. Вы можете сотворить любое известное вам заклинание барда в качестве ритуала, если заклинание позволяет это. Вы можете использовать ваш музыкальный инструмент в качестве фокусировки для ваших заклинаний барда.",
                    Description_EN = "You regain all expended spell slots when you finish a long rest. You use your Charisma whenever a spell refers to your spellcasting ability. Spell save DC = 8 + your proficiency bonus + your Charisma modifier. Spell attack modifier = your proficiency bonus + your Charisma modifier. You can cast any bard spell you know as a ritual if that spell has the ritual tag. You can use a musical instrument (found in chapter 5) as a spellcasting focus for your bard spells.",
                },
                new Feature
                {
                    LevelToGain = 1, Name_RU = "Вдохновение Барда", Name_EN = "Bardic Inspiration",
                    Description_RU = "Своими словами или музыкой вы можете вдохновлять других. Для этого вы должны бонусным действием выбрать одно существо, отличное от вас, в пределах 60 футов, которое может вас слышать. Это существо получает кость бардовского вдохновения — к6.\n\nВ течение следующих 10 минут это существо может один раз бросить эту кость и добавить результат к проверке характеристики, броску атаки или спасброску, который оно совершает. Существо может принять решение о броске кости вдохновения уже после броска к20, но должно сделать это прежде, чем Мастер объявит результат броска. Как только кость бардовского вдохновения брошена, она исчезает. Существо может иметь только одну такую кость одновременно.\n\nВы можете использовать это умение количество раз, равное модификатору вашей Харизмы, но как минимум один раз. Потраченные использования этого умения восстанавливаются после продолжительного отдыха.\n\nВаша кость бардовского вдохновения изменяется с ростом вашего уровня в этом классе. Она становится к8 на 5-м уровне, к10 на 10-м уровне и к12 на 15-м уровне.",
                    Description_EN = "You can inspire others through stirring words or music. To do so, you use a bonus action on your turn to choose one creature other than yourself within 60 feet of you who can hear you. That creature gains one Bardic Inspiration die, a d6.\n\nOnce within the next 10 minutes, the creature can roll the die and add the number rolled to one ability check, attack roll, or saving throw it makes. The creature can wait until after it rolls the d20 before deciding to use the Bardic Inspiration die, but must decide before the DM says whether the roll succeeds or fails. Once the Bardic Inspiration die is rolled, it is lost. A creature can have only one Bardic Inspiration die at a time.\n\nYou can use this feature a number of times equal to your Charisma modifier (a minimum of once). You regain any expended uses when you finish a long rest.\n\nYour Bardic Inspiration die changes when you reach certain levels in this class. The die becomes a d8 at 5th level, a d10 at 10th level, and a d12 at 15th level.",
                    GetMaxUses = c => c.Attributes.Charisma.Modifier(), MinimumOfMaxUses = 1, ResetAfter = ERest.Long
                }
            }}
        };
    }
}
