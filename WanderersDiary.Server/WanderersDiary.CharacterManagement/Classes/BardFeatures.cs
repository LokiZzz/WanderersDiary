using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Text;
using WanderersDiary.CharacterManagement.Extensions;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Utility;
using WanderersDiary.Shared.Game;
using WanderersDiary.Shared.Game.Enums;
using static System.Net.WebRequestMethods;

namespace WanderersDiary.CharacterManagement.Classes
{
    public static class BardFeatures
    {
        public static List<Feature> Features => new List<Feature>
        {
            new Feature { Index = 1, LevelToGain = 1, Name = new LocalizedString { RU = "Использование заклинаний", EN = "Spellcasting" },
                Description = new LocalizedString() {
                    RU = "<p>Вы научились изменять ткань реальности в соответствии с вашими волей и музыкой. Ваши заклинания являются частью вашего обширного репертуара; это магия, которой вы найдёте применение в любой ситуации.</p><br><h3>Заговоры (заклинания 0-го уровня)</h3><p>Вы знаете два заговора из списка доступных для барда на ваш выбор. При достижении более высоких уровней вы выучите новые, в соответствии с колонкой «известные заговоры».</p><br><h3>Ячейки заклинаний</h3><p>Таблица «Бард» показывает, сколько ячеек заклинаний у вас есть для заклинаний барда 1-го и других уровней. Для накладывания заклинания вы должны потратить ячейку соответствующего либо превышающего уровня. Вы восстанавливаете все потраченные ячейки в конце продолжительного отдыха. Например, если вы знаете заклинание 1-го уровня лечение ран [cure wounds], и у вас есть ячейки 1-го и 2-го уровней, вы можете наложить его с помощью любой из этих ячеек.</p><br><h3>Известные заклинания первого и более высоких уровней</h3><p>Вы знаете четыре заклинания 1-го уровня на свой выбор из списка доступных барду.</p><p>Колонка «известные заклинания» показывает, когда вы сможете выучить новые заклинания. Уровень заклинаний не должен превышать уровень самой высокой имеющейся у вас ячейки заклинаний. Например, когда вы достигнете 3-го уровня в этом классе, вы можете выучить одно новое заклинание 1-го или 2-го уровня.</p><p>Кроме того, когда вы получаете новый уровень в этом классе, вы можете одно из известных вам заклинаний барда заменить на другое из списка барда, уровень которого тоже должен соответствовать имеющимся ячейкам заклинаний.</p><br><h3>Базовая характеристика заклинаний</h3><p>При накладывании заклинаний бард использует свою Харизму. Ваша магия проистекает из сердечности и душевности, которую вы вкладываете в исполнение музыки и произнесение речей. Вы используете Харизму в случаях, когда заклинание ссылается на базовую характеристику. Кроме того, вы используете Харизму при определении Сл спасбросков от ваших заклинаний, и при броске атаки заклинаниями.</p><p><strong>Сл спасброска</strong> = 8 + ваш бонус мастерства + ваш модификатор Харизмы</p><p><strong>Модификатор броска атаки </strong>= ваш бонус мастерства + ваш модификатор Харизмы</p><br><h3>Ритуальное колдовство</h3><p>Вы можете сотворить любое известное вам заклинание барда в качестве ритуала, если заклинание позволяет это.</p><br><h3>Фокусировка заклинания</h3><p>Вы можете использовать ваш музыкальный инструмент в качестве фокусировки для ваших заклинаний барда.</p>",
                    EN = "<p>You have learned to untangle and reshape the fabric of reality in harmony with your wishes and music. Your spells are part of your vast repertoire, magic that you can tune to different situations.</p><h3>Cantrips</h3><p>You know two cantrips of your choice from the bard spell list. You learn additional bard cantrips of your choice at higher levels, as shown in the Cantrips Known column of the Bard table.</p><h3>Spell Slots</h3><p>The Bard table shows how many spell slots you have to cast your bard spells of 1st level and higher. To cast one of these spells, you must expend a slot of the spell's level or higher. You regain all expended spell slots when you finish a long rest. For example, if you know the 1st-level spell Cure Wounds</a> and have a 1st-level and a 2nd-level spell slot available, you can cast Cure Wounds using either slot.</p><h3>Spells Known of 1st Level and Higher</h3><p>You know four 1st-level spells of your choice from the bard spell list.</p><p>The Spells Known column of the Bard table shows when you learn more bard spells of your choice. Each of these spells must be of a level for which you have spell slots, as shown on the table. For instance, when you reach 3rd level in this class, you can learn one new spell of 1st or 2nd level.</p><p>Additionally, when you gain a level in this class, you can choose one of the bard spells you know and replace it with another spell from the bard spell list, which also must be of a level for which you have spell slots.</p><h3>Spellcasting Ability</h3><p>Charisma is your spellcasting ability for your bard spells. Your magic comes from the heart and soul you pour into the performance of your music or oration. You use your Charisma whenever a spell refers to your spellcasting ability. In addition, you use your Charisma modifier when setting the saving throw DC for a bard spell you cast and when making an attack roll with one.</p><p><strong>Spell save DC</strong> = 8 + your proficiency bonus + your Charisma modifier</p><p><strong>Spell attack modifier</strong> = your proficiency bonus + your Charisma modifier</p><h3>Ritual Casting</h3><p>You can cast any bard spell you know as a ritual if that spell has the ritual tag.</p><h3>Spellcasting Focus</h3><p>You can use a musical instrument (found in chapter 5) as a spellcasting focus for your bard spells.</p>",
                }
            },
            new Feature { Index = 2,  LevelToGain = 1, Name = new LocalizedString { RU = "Вдохновение Барда", EN = "Bardic Inspiration" },
                Description = new LocalizedString() {
                    RU = "<p>Своими словами или музыкой вы можете вдохновлять других. Для этого вы должны бонусным действием выбрать одно существо, отличное от вас, в пределах 60 футов, которое может вас слышать. Это существо получает кость бардовского вдохновения — к6.</p><p>В течение следующих 10 минут это существо может один раз бросить эту кость и добавить результат к проверке характеристики, броску атаки или спасброску, который оно совершает. Существо может принять решение о броске кости вдохновения уже после броска к20, но должно сделать это прежде, чем Мастер объявит результат броска. Как только кость бардовского вдохновения брошена, она исчезает. Существо может иметь только одну такую кость одновременно.</p><p>Вы можете использовать это умение количество раз, равное модификатору вашей Харизмы, но как минимум один раз. Потраченные использования этого умения восстанавливаются после продолжительного отдыха.</p><p>Ваша кость бардовского вдохновения изменяется с ростом вашего уровня в этом классе. Она становится к8 на 5-м уровне, к10 на 10-м уровне и к12 на 15-м уровне.</p>",
                    EN = "<p>You can inspire others through stirring words or music. To do so, you use a bonus action on your turn to choose one creature other than yourself within 60 feet of you who can hear you. That creature gains one Bardic Inspiration die, a d6.</p><p>Once within the next 10 minutes, the creature can roll the die and add the number rolled to one ability check, attack roll, or saving throw it makes. The creature can wait until after it rolls the d20 before deciding to use the Bardic Inspiration die, but must decide before the DM says whether the roll succeeds or fails. Once the Bardic Inspiration die is rolled, it is lost. A creature can have only one Bardic Inspiration die at a time.</p><p>You can use this feature a number of times equal to your Charisma modifier (a minimum of once). You regain any expended uses when you finish a long rest.</p><p>Your Bardic Inspiration die changes when you reach certain levels in this class. The die becomes a d8 at 5th level, a d10 at 10th level, and a d12 at 15th level.</p>",
                },
                GetMaxUses = c => c.Attributes.Charisma.Modifier(), MinimumOfMaxUses = 1, ResetAfter = ERest.Long
            },
            new Feature { Index = 3, LevelToGain = 2, Name = new LocalizedString { RU = "Мастер на Все Руки", EN = "Bardic Inspiration" },
                Description = new LocalizedString() {
                    RU = "<p>Вы можете добавлять половину бонуса мастерства, округлённую в меньшую сторону, ко всем проверкам характеристик, куда этот бонус еще не включён.</p>",
                    EN = "<p>Starting at 2nd level, you can add half your proficiency bonus, rounded down, to any ability check you make that doesn't already include your proficiency bonus.</p>",
                }
            },
            new Feature { Index = 4, LevelToGain = 2, Name = new LocalizedString { RU = "Песнь Отдыха", EN = "Song of Rest" },
                Description = new LocalizedString() {
                    RU = "<p>Вы с помощью успокаивающей музыки или речей можете помочь своим раненым союзникам восстановить их силы во время короткого отдыха. Если вы или любые союзные существа, способные слышать ваше исполнение, восстанавливаете хиты в конце короткого отдыха, тратя хотя бы одну Кость Хитов, каждый из вас восстанавливает дополнительно 1к6 хитов.</p><p>Количество дополнительно восстанавливаемых хитов растёт с вашим уровнем в этом классе: 1к8 на 9-м уровне, 1к10 на 13 уровне и 1к12 на 17 уровне.</p>",
                    EN = "<p>Beginning at 2nd level, you can use soothing music or oration to help revitalize your wounded allies during a short rest. If you or any friendly creatures who can hear your performance regain hit points at the end of the short rest by spending one or more Hit Dice, each of those creatures regains an extra 1d6 hit points.</p><p>The extra Hit Points increase when you reach certain levels in this class: to 1d8 at 9th level, to 1d10 at 13th level, and to 1d12 at 17th level.</p>",
                }
            },
            new Feature { Index = 5, LevelToGain = 3, Name = new LocalizedString { RU = "Коллегия Бардов", EN = "Bard College" },
                Description = new LocalizedString() {
                    RU = "<p>Вы углубляетесь в традиции выбранной вами коллегии бардов. Все коллегии описаны в конце описания класса. Этот выбор предоставляет вам умения на 3-м, 6-м и 14-м уровнях.</p>",
                    EN = "<p>At 3rd level, you delve into the advanced techniques of a bard college of your choice. Your choice grants you features at 3rd level and again at 6th and 14th level.</p>",
                }
            },
            new Feature { Index = 6, LevelToGain = 3, Name = new LocalizedString { RU = "Компетентность", EN = "Expertise" },
                Description = new LocalizedString() {
                    RU = "<p>Выберите 2 навыка из тех, которыми вы владеете. Ваш бонус мастерства для этих навыков удваивается.</p><p>На 10-м уровне вы можете выбрать еще 2 навыка и получить для них это преимущество.</p>",
                    EN = "<p>At 3rd level, choose two of your skill proficiencies. Your proficiency bonus is doubled for any ability check you make that uses either of the chosen proficiencies.</p><p>At 10th level, you can choose another two skill proficiencies to gain this benefit.</p>",
                }
            },
            new Feature { Index = 7, LevelToGain = 5, Name = new LocalizedString { RU = "Источник Вдохновения", EN = "Font of Inspiration" },
                Description = new LocalizedString() {
                    RU = "<p>Вы восстанавливаете истраченные вдохновения барда и после короткого и после продолжительного отдыха.</p>",
                    EN = "<p>Beginning when you reach 5th level, you regain all of your expended uses of Bardic Inspiration when you finish a short or long rest.</p>",
                }
            },
            new Feature { Index = 8, LevelToGain = 6, Name = new LocalizedString { RU = "Контрочарование", EN = "Countercharm" },
                Description = new LocalizedString() {
                    RU = "<p>Вы получаете возможность использовать звуки или слова силы для разрушения воздействующих на разум эффектов. Вы можете действием начать исполнение, которое продлится до конца вашего следующего хода. В течение этого времени вы и все дружественные существа в пределах 30 футов от вас совершают спасброски от запугивания и очарования с преимуществом. Чтобы получить это преимущество, существа должны слышать вас. Исполнение заканчивается преждевременно, если вы оказываетесь недееспособны, теряете способность говорить, или прекращаете исполнение добровольно (на это не требуется действие).</p>",
                    EN = "<p>At 6th level, you gain the ability to use musical notes or words of power to disrupt mind-influencing effects. As an action, you can start a performance that lasts until the end of your next turn. During that time, you and any friendly creatures within 30 feet of you have advantage on saving throws against being frightened or charmed. A creature must be able to hear you to gain this benefit. The performance ends early if you are incapacitated or silenced or if you voluntarily end it (no action required).</p>",
                }
            },
            new Feature { Index = 9, LevelToGain = 10, Name = new LocalizedString { RU = "Тайны Магии", EN = "Magical Secrets" },
                Description = new LocalizedString() {
                    RU = "<p>Вы успели набрать знаний из самого широкого спектра магических дисциплин. Выберите два заклинания любых классов, включая ваш собственный. Эти заклинания должны быть того уровня, который вы можете использовать, или являться заговорами.</p><p>Теперь эти заклинания считаются для вас заклинаниями барда, и они уже включены в общее количество известных вам заклинаний согласно таблице «Бард». Ещё по два заклинания других классов вы выучите на 14-м и 18-м уровнях.</p>",
                    EN = "<p>By 10th level, you have plundered magical knowledge from a wide spectrum of disciplines. Choose two spells from any classes, including this one. A spell you choose must be of a level you can cast, as shown on the Bard table, or a cantrip.</p><p>The chosen spells count as bard spells for you and are included in the number in the Spells Known column of the Bard table.</p><p>You learn two additional spells from any classes at 14th level and again at 18th level.</p>",
                }
            },
            new Feature { Index = 10, LevelToGain = 20, Name = new LocalizedString { RU = "Превосходное Вдохновение", EN = "Superior Inspiration" },
                Description = new LocalizedString() {
                    RU = "<p>Если на момент броска инициативы у вас не осталось неиспользованных вдохновений, вы получаете одно.</p>",
                    EN = "<p>At 20th level, when you roll initiative and have no uses of Bardic Inspiration left, you regain one use.</p>",
                }
            },
        };

        public static List<ArchetypeFeatures> ArchetypeFeatures => new List<ArchetypeFeatures> 
        {
            new ArchetypeFeatures { ArchetypeIndex = (int)EBardArchetypes.Valor, Features = new List<Feature>
            {
                new Feature { Index = 101, LevelToGain = 3, Name = new LocalizedString { RU = "Дополнительные Навыки", EN = "Bonus Proficiencies" },
                    Description = new LocalizedString() {
                        RU = "<p>Присоединяясь к коллегии доблести, вы получаете владение средними доспехами, щитами и воинским оружием.</p>",
                        EN = "<p>When you join the College of Valor at 3rd level, you gain proficiency with medium armor, shields, and martial weapons.</p>",
                    }
                },
                new Feature { Index = 102, LevelToGain = 3, Name = new LocalizedString { RU = "Боевое Вдохновение", EN = "Combat Inspiration" },
                    Description = new LocalizedString() {
                        RU = "<p>Вы узнаёте, как вдохновлять других в бою. Существо, получившее от вас кость бардовского вдохновения, может бросить эту кость и добавить результат к своему броску урона оружием. В качестве альтернативы, если существо атаковано, оно может реакцией совершить бросок кости вдохновения и добавить результат к своему КД от этой атаки. Оно может сделать это после броска атаки, но до того, как узнает, попали ли по нему.</p>",
                        EN = "<p>Also at 3rd level, you learn to inspire others in battle. A creature that has a Bardic Inspiration die from you can roll that die and add the number rolled to a weapon damage roll it just made. Alternatively, when an attack roll is made against the creature, it can use its reaction to roll the Bardic Inspiration die and add the number rolled to its AC against that attack, after seeing the roll but before knowing whether it hits or misses.</p>",
                    }
                },
                new Feature { Index = 103, LevelToGain = 6, Name = new LocalizedString { RU = "Дополнительная Атака", EN = "Extra Attack" },
                    Description = new LocalizedString() {
                        RU = "<p>Если вы в свой ход совершаете действие Атака, вы можете совершить две атаки вместо одной.</p>",
                        EN = "<p>Starting at 6th level, you can attack twice, instead of once, whenever you take the Attack action on your turn.</p>",
                    }
                },
                new Feature { Index = 104, LevelToGain = 6, Name = new LocalizedString { RU = "Дополнительная Атака", EN = "Extra Attack" },
                    Description = new LocalizedString() {
                        RU = "<p>Если вы в свой ход совершаете действие Атака, вы можете совершить две атаки вместо одной.</p>",
                        EN = "<p>Starting at 6th level, you can attack twice, instead of once, whenever you take the Attack action on your turn.</p>",
                    }
                },
                new Feature { Index = 105, LevelToGain = 14, Name = new LocalizedString { RU = "Боевая Магия", EN = "Battle Magic" },
                    Description = new LocalizedString() {
                        RU = "<p>Вы научились сплетать использование заклинаний и оружия в одно гармоничное действие. Если вы действием используете заклинание барда, вы можете бонусным действием совершить одну атаку оружием.</p>",
                        EN = "<p>At 14th level, you have mastered the art of weaving spellcasting and weapon use into a single harmonious act. When you use your action to cast a bard spell, you can make one weapon attack as a bonus action.</p>",
                    }
                },
            }},
            new ArchetypeFeatures { ArchetypeIndex = (int)EBardArchetypes.Lore, Features = new List<Feature>
            {
                new Feature { Index = 201, LevelToGain = 3, Name = new LocalizedString { RU = "Дополнительные Навыки", EN = "Bonus Proficiencies" },
                    Description = new LocalizedString() {
                        RU = "<p>Если вы присоединяетесь к коллегии знаний, вы овладеваете тремя навыками на ваш выбор.</p>",
                        EN = "<p>When you join the College of Lore at 3rd level, you gain proficiency with three skills of your choice.</p>",
                    }
                },
                new Feature { Index = 202, LevelToGain = 3, Name = new LocalizedString { RU = "Острое Словцо", EN = "Cutting Words" },
                    Description = new LocalizedString() {
                        RU = "<p>Если вы присоединяетесь к коллегии знаний, вы овладеваете тремя навыками на ваш выбор.</p>",
                        EN = "<p>Вы узнаёте, как использовать собственное остроумие, чтобы отвлечь, смутить или по-другому подорвать способности и уверенность противников. Если существо, которое вы можете видеть, в пределах 60 футов от вас совершает бросок атаки, урона или проверку характеристики, вы можете реакцией потратить одну из ваших костей бардовского вдохновения, и вычесть результат броска этой кости из броска этого существа. Вы можете принять решение об использовании этого умения после броска существа, но до того момента, когда Мастер объявит результат броска или проверки. Существо не подвержено этому умению, если не может слышать вас, или обладает иммунитетом к очарованию.</p>",
                    }
                },
                new Feature { Index = 203, LevelToGain = 6, Name = new LocalizedString { RU = "Дополнительные Тайны Магии", EN = "Additional Magical Secrets" },
                    Description = new LocalizedString() {
                        RU = "<p>Вы можете выучить 2 заклинания из доступных любому классу на свой выбор. Их уровень не должен превышать уровня заклинаний, которые вы можете использовать на этом уровне. Они также могут быть заговорами. Выбранные заклинания теперь считаются для вас заклинаниями барда, но они не учитываются в общем количестве известных вам заклинаний барда.</p>",
                        EN = "<p>At 6th level, you learn two spells of your choice from any class. A spell you choose must be of a level you can cast, as shown on the Bard table, or a cantrip. The chosen spells count as bard spells for you but don't count against the number of bard spells you know.</p>",
                    }
                },
                new Feature { Index = 204, LevelToGain = 14, Name = new LocalizedString { RU = "Непревзойдённый Навык", EN = "Peerless Skill" },
                    Description = new LocalizedString() {
                        RU = "<p>Если вы совершаете проверку характеристики, вы можете бросить кость бардовского вдохновения и добавить результат к проверке. Вы можете принять решение об использовании этого умения после броска проверки, но до того, как Мастер объявит результат этой проверки.</p>",
                        EN = "<p>Starting at 14th level, when you make an ability check, you can expend one use of Bardic Inspiration. Roll a Bardic Inspiration die and add the number rolled to your ability check. You can choose to do so after you roll the die for the ability check, but before the DM tells you whether you succeed or fail.</p>",
                    }
                },
            }},
        };
    }
}