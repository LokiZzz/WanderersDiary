using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Utility;
using static System.Reflection.Metadata.BlobBuilder;

namespace WanderersDiary.TestConsole
{
    public static class Races
    {
        public static async Task<List<Race>> GetRacesAsync()
        {
            List<Race> races = new List<Race>();

            Dictionary<string, string> names = GetNames();
            string html = await GetRaceHtml(names.First().Key);

            Race race = new Race
            {
                Name = new LocalizedString
                {
                    EN = names.First().Key,
                    RU = names.First().Value
                },

            };

            return races;
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
            response = await client.GetAsync($"https://dnd5.club/races/fragment/{id}");
            string result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
