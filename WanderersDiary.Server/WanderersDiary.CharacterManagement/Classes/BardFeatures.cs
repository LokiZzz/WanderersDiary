using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Extensions;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Utility;
using WanderersDiary.Shared.Game;
using WanderersDiary.Shared.Game.Enums;

namespace WanderersDiary.CharacterManagement.Classes
{
    public static class BardFeatures
    {
        public static List<ClassFeatures> Features => new List<ClassFeatures>
        {
            new ClassFeatures { Level = 1, Features = new List<Feature>
            {
                new Feature
                {
                    Index = 1, LevelToGain = 1, Name = new LocalizedString { RU = "Использование заклинаний", EN = "Spellcasting" },
                    Description = new LocalizedString() {
                        RU = "<p>Вы научились изменять ткань реальности в соответствии с вашими волей и музыкой. Ваши заклинания являются частью вашего обширного репертуара; это магия, которой вы найдёте применение в любой ситуации.</p><br><h3>Заговоры (заклинания 0-го уровня)</h3><p>Вы знаете два заговора из списка доступных для барда на ваш выбор. При достижении более высоких уровней вы выучите новые, в соответствии с колонкой «известные заговоры».</p><br><h3>Ячейки заклинаний</h3><p>Таблица «Бард» показывает, сколько ячеек заклинаний у вас есть для заклинаний барда 1-го и других уровней. Для накладывания заклинания вы должны потратить ячейку соответствующего либо превышающего уровня. Вы восстанавливаете все потраченные ячейки в конце продолжительного отдыха. Например, если вы знаете заклинание 1-го уровня лечение ран [cure wounds], и у вас есть ячейки 1-го и 2-го уровней, вы можете наложить его с помощью любой из этих ячеек.</p><br><h3>Известные заклинания первого и более высоких уровней</h3><p>Вы знаете четыре заклинания 1-го уровня на свой выбор из списка доступных барду.</p><p>Колонка «известные заклинания» показывает, когда вы сможете выучить новые заклинания. Уровень заклинаний не должен превышать уровень самой высокой имеющейся у вас ячейки заклинаний. Например, когда вы достигнете 3-го уровня в этом классе, вы можете выучить одно новое заклинание 1-го или 2-го уровня.</p><p>Кроме того, когда вы получаете новый уровень в этом классе, вы можете одно из известных вам заклинаний барда заменить на другое из списка барда, уровень которого тоже должен соответствовать имеющимся ячейкам заклинаний.</p><br><h3>Базовая характеристика заклинаний</h3><p>При накладывании заклинаний бард использует свою Харизму. Ваша магия проистекает из сердечности и душевности, которую вы вкладываете в исполнение музыки и произнесение речей. Вы используете Харизму в случаях, когда заклинание ссылается на базовую характеристику. Кроме того, вы используете Харизму при определении Сл спасбросков от ваших заклинаний, и при броске атаки заклинаниями.</p><p><strong>Сл спасброска</strong> = 8 + ваш бонус мастерства + ваш модификатор Харизмы</p><p><strong>Модификатор броска атаки </strong>= ваш бонус мастерства + ваш модификатор Харизмы</p><br><h3>Ритуальное колдовство</h3><p>Вы можете сотворить любое известное вам заклинание барда в качестве ритуала, если заклинание позволяет это.</p><br><h3>Фокусировка заклинания</h3><p>Вы можете использовать ваш музыкальный инструмент в качестве фокусировки для ваших заклинаний барда.</p>",
                        EN = "<p>You have learned to untangle and reshape the fabric of reality in harmony with your wishes and music. Your spells are part of your vast repertoire, magic that you can tune to different situations.</p><h3>Cantrips</h3><p>You know two cantrips of your choice from the bard spell list. You learn additional bard cantrips of your choice at higher levels, as shown in the Cantrips Known column of the Bard table.</p><h3>Spell Slots</h3><p>The Bard table shows how many spell slots you have to cast your bard spells of 1st level and higher. To cast one of these spells, you must expend a slot of the spell's level or higher. You regain all expended spell slots when you finish a long rest. For example, if you know the 1st-level spell Cure Wounds</a> and have a 1st-level and a 2nd-level spell slot available, you can cast Cure Wounds using either slot.</p><h3>Spells Known of 1st Level and Higher</h3><p>You know four 1st-level spells of your choice from the bard spell list.</p><p>The Spells Known column of the Bard table shows when you learn more bard spells of your choice. Each of these spells must be of a level for which you have spell slots, as shown on the table. For instance, when you reach 3rd level in this class, you can learn one new spell of 1st or 2nd level.</p><p>Additionally, when you gain a level in this class, you can choose one of the bard spells you know and replace it with another spell from the bard spell list, which also must be of a level for which you have spell slots.</p><h3>Spellcasting Ability</h3><p>Charisma is your spellcasting ability for your bard spells. Your magic comes from the heart and soul you pour into the performance of your music or oration. You use your Charisma whenever a spell refers to your spellcasting ability. In addition, you use your Charisma modifier when setting the saving throw DC for a bard spell you cast and when making an attack roll with one.</p><p><strong>Spell save DC</strong> = 8 + your proficiency bonus + your Charisma modifier</p><p><strong>Spell attack modifier</strong> = your proficiency bonus + your Charisma modifier</p><h3>Ritual Casting</h3><p>You can cast any bard spell you know as a ritual if that spell has the ritual tag.</p><h3>Spellcasting Focus</h3><p>You can use a musical instrument (found in chapter 5) as a spellcasting focus for your bard spells.</p>",
                    }
                },
                new Feature
                {
                    Index = 2,  LevelToGain = 1, Name = new LocalizedString { RU = "Вдохновение Барда", EN = "Bardic Inspiration" },
                    Description = new LocalizedString() {
                        RU = "<p>Своими словами или музыкой вы можете вдохновлять других. Для этого вы должны бонусным действием выбрать одно существо, отличное от вас, в пределах 60 футов, которое может вас слышать. Это существо получает кость бардовского вдохновения — к6.</p><p>В течение следующих 10 минут это существо может один раз бросить эту кость и добавить результат к проверке характеристики, броску атаки или спасброску, который оно совершает. Существо может принять решение о броске кости вдохновения уже после броска к20, но должно сделать это прежде, чем Мастер объявит результат броска. Как только кость бардовского вдохновения брошена, она исчезает. Существо может иметь только одну такую кость одновременно.</p><p>Вы можете использовать это умение количество раз, равное модификатору вашей Харизмы, но как минимум один раз. Потраченные использования этого умения восстанавливаются после продолжительного отдыха.</p><p>Ваша кость бардовского вдохновения изменяется с ростом вашего уровня в этом классе. Она становится к8 на 5-м уровне, к10 на 10-м уровне и к12 на 15-м уровне.</p>",
                        EN = "<p>You can inspire others through stirring words or music. To do so, you use a bonus action on your turn to choose one creature other than yourself within 60 feet of you who can hear you. That creature gains one Bardic Inspiration die, a d6.</p><p>Once within the next 10 minutes, the creature can roll the die and add the number rolled to one ability check, attack roll, or saving throw it makes. The creature can wait until after it rolls the d20 before deciding to use the Bardic Inspiration die, but must decide before the DM says whether the roll succeeds or fails. Once the Bardic Inspiration die is rolled, it is lost. A creature can have only one Bardic Inspiration die at a time.</p><p>You can use this feature a number of times equal to your Charisma modifier (a minimum of once). You regain any expended uses when you finish a long rest.</p><p>Your Bardic Inspiration die changes when you reach certain levels in this class. The die becomes a d8 at 5th level, a d10 at 10th level, and a d12 at 15th level.</p>",
                    },
                    GetMaxUses = c => c.Attributes.Charisma.Modifier(), MinimumOfMaxUses = 1, ResetAfter = ERest.Long
                },
            }},
            new ClassFeatures { Level = 2, Features = new List<Feature>
            {
                new Feature
                {
                    Index = 3, LevelToGain = 2, Name = new LocalizedString { RU = "Мастер на Все Руки", EN = "Bardic Inspiration" },
                    Description = new LocalizedString() {
                        RU = "<p>Вы можете добавлять половину бонуса мастерства, округлённую в меньшую сторону, ко всем проверкам характеристик, куда этот бонус еще не включён.</p>",
                        EN = "<p>Starting at 2nd level, you can add half your proficiency bonus, rounded down, to any ability check you make that doesn't already include your proficiency bonus.</p>",
                    }
                },
                new Feature
                {
                    Index = 4, LevelToGain = 2, Name = new LocalizedString { RU = "Песнь Отдыха", EN = "Song of Rest" },
                    Description = new LocalizedString() {
                        RU = "<p>Вы с помощью успокаивающей музыки или речей можете помочь своим раненым союзникам восстановить их силы во время короткого отдыха. Если вы или любые союзные существа, способные слышать ваше исполнение, восстанавливаете хиты в конце короткого отдыха, тратя хотя бы одну Кость Хитов, каждый из вас восстанавливает дополнительно 1к6 хитов.</p><p>Количество дополнительно восстанавливаемых хитов растёт с вашим уровнем в этом классе: 1к8 на 9-м уровне, 1к10 на 13 уровне и 1к12 на 17 уровне.</p>",
                        EN = "<p>Beginning at 2nd level, you can use soothing music or oration to help revitalize your wounded allies during a short rest. If you or any friendly creatures who can hear your performance regain hit points at the end of the short rest by spending one or more Hit Dice, each of those creatures regains an extra 1d6 hit points.</p><p>The extra Hit Points increase when you reach certain levels in this class: to 1d8 at 9th level, to 1d10 at 13th level, and to 1d12 at 17th level.</p>",
                    }
                }
            }},
            new ClassFeatures { Level = 3, Features = new List<Feature>
            {
                new Feature
                {
                    Index = 5, LevelToGain = 3, Name = new LocalizedString { RU = "Коллегия Бардов", EN = "Bard College" },
                    Description = new LocalizedString() {
                        RU = "<p>Вы углубляетесь в традиции выбранной вами коллегии бардов. Все коллегии описаны в конце описания класса. Этот выбор предоставляет вам умения на 3-м, 6-м и 14-м уровнях.</p>",
                        EN = "<p>At 3rd level, you delve into the advanced techniques of a bard college of your choice. Your choice grants you features at 3rd level and again at 6th and 14th level.</p>",
                    }
                },
                new Feature
                {
                    Index = 6, LevelToGain = 3, Name = new LocalizedString { RU = "Компетентность", EN = "Expertise" },
                    Description = new LocalizedString() {
                        RU = "<p>Выберите 2 навыка из тех, которыми вы владеете. Ваш бонус мастерства для этих навыков удваивается.</p><p>На 10-м уровне вы можете выбрать еще 2 навыка и получить для них это преимущество.</p>",
                        EN = "<p>At 3rd level, choose two of your skill proficiencies. Your proficiency bonus is doubled for any ability check you make that uses either of the chosen proficiencies.</p><p>At 10th level, you can choose another two skill proficiencies to gain this benefit.</p>",
                    }
                },
            }},
            new ClassFeatures { Level = 5, Features = new List<Feature>
            {
                new Feature
                {
                    Index = 7, LevelToGain = 5, Name = new LocalizedString { RU = "Источник Вдохновения", EN = "Font of Inspiration" },
                    Description = new LocalizedString() {
                        RU = "<p>Вы восстанавливаете истраченные вдохновения барда и после короткого и после продолжительного отдыха.</p>",
                        EN = "<p>Beginning when you reach 5th level, you regain all of your expended uses of Bardic Inspiration when you finish a short or long rest.</p>",
                    }
                },
            }},
        };

        public static List<ArchetypeFeatures> ArchetypeFeatures => new List<ArchetypeFeatures> {
            new ArchetypeFeatures { ArchetypeIndex = 1, Level = 3, Features = new List<Feature>
            {
                new Feature
                {

                }
            }},
        };
    }
}
