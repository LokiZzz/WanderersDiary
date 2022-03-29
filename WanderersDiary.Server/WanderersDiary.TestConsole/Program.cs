using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using WanderersDiary.CharacterManagement;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Enums;
using WanderersDiary.CharacterManagement.Models.Game;
using WanderersDiary.CharacterManagement.Models.Utility;
using WanderersDiary.CharacterManagement.Static;

namespace WanderersDiary.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if(File.Exists("FeatureTitleMapping.json"))
            {
                string featureMappingFileContent = File.ReadAllText("FeatureTitleMapping.json");
                Races.FeatureTitlesMapping = JsonConvert.DeserializeObject<Dictionary<string, string>>(featureMappingFileContent);
            }

            List<Race> races = Races.GetRacesAsync().GetAwaiter().GetResult();
            string racesJSON = JsonConvert.SerializeObject(races);

            Console.ReadLine();
        }
    }
}
