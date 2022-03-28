using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Enums;
using WanderersDiary.CharacterManagement.Models.Utility;
using static System.Formats.Asn1.AsnWriter;
using static System.Reflection.Metadata.BlobBuilder;

namespace WanderersDiary.TestConsole
{
    public static class Races
    {
        public static async Task<List<Race>> GetRacesAsync()
        {
            List<Race> races = new List<Race>();

            Dictionary<string, string> names = GetNames();

            foreach (KeyValuePair<string, string> name in names)
            {
                string html = await GetRaceHtml(name.Key);

                Race race = new Race
                {
                    Name = new LocalizedString
                    {
                        EN = name.Key,
                        RU = name.Value
                    },
                    AttributesBonusesOptions = GetAttributeBonuses(html),
                    SizesToChooseFrom = GetSizes(html),
                    Speed = GetSpeed(html),
                    Senses = GetSenses(html),
                    Features = GetFeatures(html, name.Key),
                };

                races.Add(race);
            }

            return races;
        }

        private static List<Feature> GetFeatures(string html, string enName)
        {
            List<Feature> result = new List<Feature>();

            //1. Добыть фичи расы без подрас.

            string inline = html.GetInline();
            List<string> ruTitles = GetRUFeaturesTitles(inline);
            
            foreach(string ruTitle in ruTitles)
            {
                Feature currentFeature = new Feature
                {
                    Name = new LocalizedString { RU = ruTitle.Replace(".", string.Empty), },
                    Description = new LocalizedString { RU = GetRUFeatureDescription(ruTitle, inline) }
                };



                result.Add(currentFeature);
            }

            //2. Добыть хтмл на английском и добыть от туда фичи на английском.
            //3. Сопоставить фичи на разных языках через консоль вручную.

            return result;
        }

        private static string GetRUFeatureDescription(string ruTitle, string inline)
        {
            string featureDescription =  inline.GetBetweenThe(
                $@"<summary class=""h4 header_separator""><span>{ruTitle}</span></summary><div class=""content""><div><p>",
                @"</p></div></div></details>"
            );

            //Clear from formating
            MatchCollection matches = Regex.Matches(featureDescription, @$"(<)(.*?)(>)");
            foreach(Match match in matches)
            {
                featureDescription = featureDescription.Replace(match.ToString(), string.Empty);
            }

            return featureDescription;
        }

        private static List<string> GetRUFeaturesTitles(string inline)
        {
            List<string> titles = inline.GetAllBetweenThe(
                @"<summary class=""h4 header_separator""><span>",
                @"</span></summary><div class=""content""><div><p>"
            );

            titles = titles
                .Where(t => !t.Equals("Увеличение характеристик.")
                    && !t.Equals("Скорость.")
                    && !t.Equals("Размер.")
                    && !t.Equals("Имена")
                    && !t.Equals("Описание"))
                .ToList();

            titles = titles.OrderBy(t => t == "Тёмное зрение" ? 1 : 0).ToList();
            titles = titles.OrderBy(t => t == "Возраст" ? 1 : 0).ToList();
            titles = titles.OrderBy(t => t == "Мировоззрение" ? 1 : 0).ToList();
            titles = titles.OrderBy(t => t == "Языки" ? 1 : 0).ToList();

            return titles;
        }

        private static Senses GetSenses(string html)
        {
            try
            {
                Senses senses = new Senses();
                string inline = html.GetInline();

                if (!inline.Contains("Темное зрение"))
                {
                    return senses;
                }

                string darkvisionString = inline.GetBetweenThe(
                    @"<div class=""score""><h4><strong class=""tip"" title=""Темное зрение"">ТЗ</strong></h4><p>",
                    @" фт.</p></div>"
                );
                senses.Darkvision = Convert.ToInt32(darkvisionString);

                return senses;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private static Speed GetSpeed(string html)
        {
            Speed speed = new Speed();
            string inline = html.GetInline();
            string speedString = inline.GetBetweenThe(
                @"<h4><strong class=""tip"" title=""Скорость"">СКР</strong></h4><p>",
                @"</p></div>"
            );

            try
            {
                string[] splittedSpeed = speedString.Split(",");

                foreach (string specificSpeedString in splittedSpeed)
                {
                    bool parsed = false;

                    if (specificSpeedString.Contains(" фт."))
                    {
                        speed.Walk = Convert.ToInt32(specificSpeedString.Replace(" фт.", string.Empty));
                        parsed = true;
                    }
                    if (specificSpeedString.Contains("летая "))
                    {
                        speed.Fly = Convert.ToInt32(specificSpeedString.Replace("летая ", string.Empty));
                        parsed = true;
                    }
                    if (specificSpeedString.Contains("лазая "))
                    {
                        speed.Climb = Convert.ToInt32(specificSpeedString.Replace("лазая ", string.Empty));
                        parsed = true;
                    }
                    if (specificSpeedString.Contains("плавая "))
                    {
                        speed.Swim = Convert.ToInt32(specificSpeedString.Replace("плавая ", string.Empty));
                        parsed = true;
                    }

                    if (!parsed)
                    {
                        string stop = "";
                    }
                }

                return speed;
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        private static List<ESize> GetSizes(string html)
        {
            List<ESize> sizes = new List<ESize>();
            string inline = html.GetInline();
            string sizeString = inline.GetBetweenThe(
                @"<strong class=""tip"" title=""Размер"">РАЗ</strong></h4><p>",
                @"</p></div><div class=""score""><h4><strong class=""tip"" title=""Скорость"">"
            );

            switch(sizeString)
            {
                case "Маленький":
                    sizes.Add(ESize.Small); break;
                case "Средний":
                    sizes.Add(ESize.Medium); break;
                case "Большой":
                    sizes.Add(ESize.Large); break;
                case "Средний или Маленький":
                    sizes.Add(ESize.Small);
                    sizes.Add(ESize.Medium);
                    break;
                default:
                    string stop = ""; break;
            }

            return sizes;
        }

        private static List<AttributesBonusesGroup> GetAttributeBonuses(string html)
        {
            try
            {
                List<AttributesBonusesGroup> bonuses = new List<AttributesBonusesGroup>();
                AttributesBonusesGroup group = new AttributesBonusesGroup();
                group.Bonuses = new List<AttributeBonus>();
                bonuses.Add(group);

                string inline = html.GetInline();
                string attributesString = inline.GetBetweenThe(
                    @"<strong class=""tip"" title=""Увеличение характеристик"">ХАР</strong></h4><p>",
                    @"</p></div><div class=""score""><h4><strong class=""tip"" title=""Размер"">РАЗ</strong></h4><p>"
                );

                if (attributesString.Equals("+1 к каждой характеристике"))
{
                    group.Bonuses.Add(GetJust1AttributeBonus(EAttribute.Strenght));
                    group.Bonuses.Add(GetJust1AttributeBonus(EAttribute.Dexterity));
                    group.Bonuses.Add(GetJust1AttributeBonus(EAttribute.Constitution));
                    group.Bonuses.Add(GetJust1AttributeBonus(EAttribute.Intelligence));
                    group.Bonuses.Add(GetJust1AttributeBonus(EAttribute.Wisdom));
                    group.Bonuses.Add(GetJust1AttributeBonus(EAttribute.Charisma));

                    return bonuses;
                }

                if (attributesString.Equals("Одну +2 и +1 или Три +1"))
                {
                    group.Bonuses.Add(new AttributeBonus
                    {
                        AttributesToSelectFrom = GetAllAttributes(),
                        Bonus = 2,
                        CountToSelect = 1
                    });
                    group.Bonuses.Add(new AttributeBonus
                    {
                        AttributesToSelectFrom = GetAllAttributes(),
                        Bonus = 1,
                        CountToSelect = 1,
                        MustBeOther = true
                    });

                    AttributesBonusesGroup group2 = new AttributesBonusesGroup { Bonuses = new List<AttributeBonus>() };
                    group2.Bonuses.Add(new AttributeBonus
                    {
                        AttributesToSelectFrom = GetAllAttributes(),
                        Bonus = 1,
                        CountToSelect = 1
                    });
                    group2.Bonuses.Add(new AttributeBonus
                    {
                        AttributesToSelectFrom = GetAllAttributes(),
                        Bonus = 1,
                        CountToSelect = 1,
                        MustBeOther = true
                    });
                    group2.Bonuses.Add(new AttributeBonus
                    {
                        AttributesToSelectFrom = GetAllAttributes(),
                        Bonus = 1,
                        CountToSelect = 1,
                        MustBeOther = true
                    });

                    bonuses.Add(group2);

                    return bonuses;
                }

                string[] splittedBonuses = attributesString.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (!splittedBonuses.Any()) return null;

                foreach (string bonusString in splittedBonuses)
                {
                    if(bonusString.Equals("к двум другим +1"))
                    {
                        group.Bonuses.Add(new AttributeBonus
                        {
                            AttributesToSelectFrom = GetAllAttributes(),
                            Bonus = 1,
                            CountToSelect = 1,
                            MustBeOther = true
                        });
                        group.Bonuses.Add(new AttributeBonus
                        {
                            AttributesToSelectFrom = GetAllAttributes(),
                            Bonus = 1,
                            CountToSelect = 1,
                            MustBeOther = true
                        });
                        break;
                    }    

                    group.Bonuses.Add(GetAttributeBonus(bonusString));
                }

                return bonuses;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private static AttributeBonus GetAttributeBonus(string bonusString)
        {
            string attributeString = bonusString.Split(" +")[0];
            string modifierString = bonusString.Split(" +")[1];
            List<EAttribute> attributes = new List<EAttribute>();
            int modifier = 0;
            bool mustBeOther = false;

            if (Int32.TryParse(modifierString, out int outModifier))
            {
                modifier = outModifier;
            }
            else
            {
                string stop = "";
            }

            switch(attributeString)
            {
                case "Сил":
                    attributes = new List<EAttribute> { EAttribute.Strenght }; break;
                case "Лов":
                    attributes = new List<EAttribute> { EAttribute.Dexterity }; break;
                case "Тел":
                    attributes = new List<EAttribute> { EAttribute.Constitution }; break;
                case "Инт":
                    attributes = new List<EAttribute> { EAttribute.Intelligence }; break;
                case "Мдр":
                    attributes = new List<EAttribute> { EAttribute.Wisdom }; break;
                case "Хар":
                    attributes = new List<EAttribute> { EAttribute.Charisma }; break;
                case "к одной другой":
                    attributes = GetAllAttributes();
                    mustBeOther = true;
                    break;
                default:
                    break;
            }

            return new AttributeBonus { 
                AttributesToSelectFrom = attributes, 
                Bonus = modifier, 
                MustBeOther = mustBeOther,
                CountToSelect = 1,
            };
        }

        private static List<EAttribute> GetAllAttributes()
        {
            return new List<EAttribute> {
                EAttribute.Strenght, EAttribute.Dexterity, EAttribute.Constitution,
                EAttribute.Intelligence, EAttribute.Wisdom, EAttribute.Charisma
            };
        }

        public static AttributeBonus GetJust1AttributeBonus(EAttribute attribute)
        {
            return new AttributeBonus {
                AttributesToSelectFrom = new List<EAttribute> { attribute },
                Bonus = 1,
                MustBeOther = false,
                CountToSelect = 1,
            };
        }

        private static Dictionary<string, string> GetNames()
        {
            Dictionary<string, string> names = new Dictionary<string, string>();

            string fileContent = File.ReadAllText(@"C:\Users\lokiz\Desktop\Races.html");

            List<string> matches = fileContent.GetAllBetweenThe(
                @"<span class=""name"">",
                @"\]",
                @"[^""]*"
            );

            foreach (string entry in matches)
            {
                string ruName = entry.Split("</span> <span>[")[0];
                string engName = entry.Split("</span> <span>[")[1];

                names.Add(engName, ruName);
            }

            return names;
        }

        private static async Task<string> GetRaceHtml(string raceName)
        {
            using HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"https://dnd5.club/races/{raceName}");
            string htmlWithId = await response.Content.ReadAsStringAsync();
            string id = htmlWithId.GetBetweenThe(@"var selectedRace = {""id"":", @",""name"":""");

            id = id.Split(",")[0];

            response = await client.GetAsync($"https://dnd5.club/races/fragment/{id}");
            string result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
