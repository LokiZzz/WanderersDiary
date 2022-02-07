using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WanderersDiary.CharacterManagement.Extensions;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.Shared.Game;
using WanderersDiary.Shared.Game.Enums;

namespace WanderersDiary.CharacterManagement.Classes
{
    public class Bard : ClassBase
    {
        public override void HandleSpecificClassFeatures(Character character, int targetLevel)
        {
            if (targetLevel >= 2) AddJackOfAllTradesSkills(character);
        }

        private void AddJackOfAllTradesSkills(Character character)
        {
            IEnumerable<ESkill> allSkills = Enum.GetValues(typeof(ESkill)).Cast<ESkill>();
            IEnumerable<ESkill> missingSkills = allSkills.Where(s => !character.Skills.Any(cs => cs.Skill == s));
            IEnumerable<SkillProficiency> skillsToAdd = missingSkills.Select(s => 
                new SkillProficiency { Skill = s, Proficiency = EProficiency.JackOfAllTrades }
            );

            character.Skills.AddRange(skillsToAdd);
        }

        public override List<ClassFeatures> Features => new List<ClassFeatures>
        {
            new ClassFeatures { Level = 1, Features = new List<Feature>
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
                },
            }},
            new ClassFeatures { Level = 2, Features = new List<Feature>
            {
                new Feature
                {
                    LevelToGain = 2, Name_RU = "Мастер на Все Руки", Name_EN = "Bardic Inspiration",
                    Description_RU = "Вы можете добавлять половину бонуса мастерства, округлённую в меньшую сторону, ко всем проверкам характеристик, куда этот бонус еще не включён.",
                    Description_EN = "Starting at 2nd level, you can add half your proficiency bonus, rounded down, to any ability check you make that doesn't already include your proficiency bonus.",
                },
                new Feature
                {
                    LevelToGain = 2, Name_RU = "Песнь Отдыха", Name_EN = "Song of Rest",
                    Description_RU = "Вы с помощью успокаивающей музыки или речей можете помочь своим раненым союзникам восстановить их силы во время короткого отдыха. Если вы или любые союзные существа, способные слышать ваше исполнение, восстанавливаете хиты в конце короткого отдыха, тратя хотя бы одну Кость Хитов, каждый из вас восстанавливает дополнительно 1к6 хитов. Количество дополнительно восстанавливаемых хитов растёт с вашим уровнем в этом классе: 1к8 на 9-м уровне, 1к10 на 13 уровне и 1к12 на 17 уровне.",
                    Description_EN = "Beginning at 2nd level, you can use soothing music or oration to help revitalize your wounded allies during a short rest. If you or any friendly creatures who can hear your performance spend one or more Hit Dice to regain hit points at the end of the short rest, each of those creatures regains an extra 1d6 hit points. The extra Hit Points increase when you reach certain levels in this class: to 1d8 at 9th level, to 1d10 at 13th level, and to 1d12 at 17th level.",
                }
            }},
        };

        //public override List<ArchetypeFeatures> ArchetypeFeatures => new List<ClassFeatures>

        public override EClass AccosiatedEClass => EClass.Bard;

        public override EDice HitDice => EDice.D8;

        public override int AvailiableNumberOfSkills => 3;

        //All skills!
        public override List<ESkill> AvailiableSkills => new List<ESkill> { 
            ESkill.Athletics,       ESkill.Acrobatics,      ESkill.SleightOfHand,   ESkill.Stealth,         ESkill.Arcana,      ESkill.History,         
            ESkill.Investigation,   ESkill.Nature,          ESkill.Religion,        ESkill.AnimalHandling,  ESkill.Insight,     ESkill.Medicine,        
            ESkill.Perception,      ESkill.Survival,        ESkill.Deception,       ESkill.Intimidation,    ESkill.Performance, ESkill.Persuasion 
        };

        public override List<ClassSpellSlots> SpellSlots => new List<ClassSpellSlots>
        {
            //----------------------1--2--3--4--5--6--7--8--9
            new ClassSpellSlots(1,  2),
            new ClassSpellSlots(2,  3),
            new ClassSpellSlots(3,  4, 2),
            new ClassSpellSlots(4,  4, 3),
            new ClassSpellSlots(5,  4, 3, 2),
            new ClassSpellSlots(6,  4, 3, 3),
            new ClassSpellSlots(7,  4, 3, 3, 1),
            new ClassSpellSlots(8,  4, 3, 3, 2),
            new ClassSpellSlots(9,  4, 3, 3, 3, 1),
            new ClassSpellSlots(10, 4, 3, 3, 3, 2),

            //----------------------1--2--3--4--5--6--7--8--9
            new ClassSpellSlots(11, 4, 3, 3, 3, 2, 1),
            new ClassSpellSlots(12, 4, 3, 3, 3, 2, 1),
            new ClassSpellSlots(13, 4, 3, 3, 3, 2, 1, 1),
            new ClassSpellSlots(14, 4, 3, 3, 3, 2, 1, 1),
            new ClassSpellSlots(15, 4, 3, 3, 3, 2, 1, 1, 1),
            new ClassSpellSlots(16, 4, 3, 3, 3, 2, 1, 1, 1),
            new ClassSpellSlots(17, 4, 3, 3, 3, 2, 1, 1, 1, 1),
            new ClassSpellSlots(18, 4, 3, 3, 3, 2, 1, 1, 1, 1),
            new ClassSpellSlots(19, 4, 3, 3, 3, 2, 2, 1, 1, 1),
            new ClassSpellSlots(20, 4, 3, 3, 3, 2, 2, 2, 1, 1),
        };
    }
}
