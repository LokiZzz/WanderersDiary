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
                    Features = await GetFeatures(html, name.Key),
                };

                races.Add(race);
            }

            return races;
        }

        private static async Task<List<Feature>> GetFeatures(string html, string enRace)
        {
            List<Feature> result = new List<Feature>();

            string inline = html.GetInline();
            List<string> ruTitles = GetRUFeaturesTitles(inline);

            Dictionary<string, string> enFeatures = await GetENFeatureDictionary(enRace);
            List<(string, string)> enFeaturesList = enFeatures.Select(f => (f.Key, f.Value)).ToList();
            
            foreach (string ruTitle in ruTitles)
            {
                result.Add(new Feature
                {
                    Name = new LocalizedString { RU = ruTitle.Replace(".", string.Empty), },
                    Description = new LocalizedString { RU = GetRUFeatureDescription(ruTitle, inline) }
                });
            }

            result.ForEach(f => TryFillKnownFeature(f, enFeaturesList));

            foreach(Feature feature in result)
            {
                if(string.IsNullOrEmpty(feature.Name.EN))
                {
                    ChooseRightTranslationManually(feature, enFeaturesList);
                }    
            }

            return result;
        }

        public static Dictionary<string, string> FeatureTitlesMapping = new Dictionary<string, string>();

        private static void ChooseRightTranslationManually(Feature currentFeature, List<(string,string)> enFeatures)
        {
            if (!enFeatures.Any() && currentFeature.Name.RU.Equals("Мировоззрение"))
            {
                return;
            }

            if(FeatureTitlesMapping.ContainsKey(currentFeature.Name.RU))
            {
                currentFeature.Name.EN = FeatureTitlesMapping[currentFeature.Name.RU].Replace(".", string.Empty);
                (string, string) enFeatureDesc = enFeatures.FirstOrDefault(f => f.Item1 == FeatureTitlesMapping[currentFeature.Name.RU]);
                currentFeature.Description.EN = enFeatureDesc.Item2;

                enFeatures.Remove(enFeatureDesc);

                return;
            }

            Console.Clear();
            Console.WriteLine($"{currentFeature.Name.RU}: {currentFeature.Description.RU}");
            Console.WriteLine($"__________________________________________________________________\n");
            
            foreach((string, string) enFeature in enFeatures)
            {
                Console.WriteLine($"{enFeatures.IndexOf(enFeature)}) {enFeature.Item1}: {enFeature.Item2}\n");
            }

            string input = Console.ReadLine();

            if(input.Equals("x"))
            {
                return;
            }

            int selected = Convert.ToInt32(input);
            currentFeature.Name.EN = enFeatures[selected].Item1.Replace(".", string.Empty);
            currentFeature.Description.EN = enFeatures[selected].Item2;

            FeatureTitlesMapping.Add(currentFeature.Name.RU, enFeatures[selected].Item1);
            string FeatureTitleMapping = JsonConvert.SerializeObject(Races.FeatureTitlesMapping);
            File.WriteAllText("FeatureTitleMapping.json", FeatureTitleMapping);

            enFeatures.RemoveAt(selected);
        }

        private static void TryFillKnownFeature(Feature currentFeature, List<(string, string)> enFeatures)
        {
            foreach ((string, string) enFeature in enFeatures.ToList())
            {
                if((enFeature.Item1.Equals("Age.") && currentFeature.Name.RU.Equals("Возраст"))
                    || (enFeature.Item1.Equals("Alignment.") && currentFeature.Name.RU.Equals("Мировоззрение"))
                    || (enFeature.Item1.Equals("Size.") && currentFeature.Name.RU.Equals("Размер"))
                    || (enFeature.Item1.Equals("Speed.") && currentFeature.Name.RU.Equals("Скорость"))
                    || (enFeature.Item1.Equals("Languages.") && currentFeature.Name.RU.Equals("Языки"))
                    || (enFeature.Item1.Equals("Darkvision.") && currentFeature.Name.RU.Equals("Тёмное зрение")))
                {
                    currentFeature.Name.EN = enFeature.Item1.Replace(".", string.Empty);
                    currentFeature.Description.EN = enFeature.Item2;

                    enFeatures.Remove(enFeature);
                }
            }
        }

        private static async Task<Dictionary<string, string>> GetENFeatureDictionary(string enRace)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            using HttpClient client = new HttpClient();

            string formattedName = enRace.ToLower().Replace("Half", "half-");
            HttpResponseMessage response = await client.GetAsync($"http://dnd5e.wikidot.com/{formattedName}");
            string html = await response.Content.ReadAsStringAsync();
            string inline = html.GetInline();

            if(formattedName.Equals("verdan"))
            {
                string stop = "";
            }

            inline = inline.Split(@"<h3 id=""toc2""><span>")[0];
            inline = inline.Split(@"<h1 id=""toc1""><span>")[0];

            List<string> enNames = inline.GetAllBetweenThe(@"<li><strong>", @"</strong>");
            if (!enNames.Any())
            {
                enNames = inline.GetAllBetweenThe(@"<p>• <strong>", @"</strong>");
            }
            enNames = enNames
                .Where(t => !t.Equals("Ability Score Increase.") && !t.Equals("Speed.") && !t.Equals("Size."))
                .ToList();
            enNames = enNames.OrderBy(t => t == "Darkvision." ? 1 : 0).ToList();
            enNames = enNames.OrderBy(t => t == "Age." ? 1 : 0).ToList();
            enNames = enNames.OrderBy(t => t == "Alignment." ? 1 : 0).ToList();
            enNames = enNames.OrderBy(t => t == "Languages." ? 1 : 0).ToList();

            foreach(string name in enNames)
            {
                string description = inline.GetBetweenThe($@"<li><strong>{name}</strong> ", @"</li></ul>");

                if(string.IsNullOrEmpty(description))
                {
                    description = inline.GetBetweenThe($@"<p>• <strong>{name}</strong> ", @"</p>");
                }

                //Clear from formating
                MatchCollection matches = Regex.Matches(description, @$"(<)(.*?)(>)");
                foreach (Match match in matches)
                {
                    description = description.Replace(match.ToString(), string.Empty);
                }

                result.Add(name, description);
            }

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
