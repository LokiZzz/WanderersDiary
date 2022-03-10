using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WanderersDiary.CharacterManagement;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Enums;

namespace WanderersDiary.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileString = File.ReadAllText("EQUIPMENT.dtn");

            Root root = JsonConvert.DeserializeObject<Root>(fileString);
            List<ItemsList> armor = root.itemsList.Where(i => i.en.type == "Armor").ToList();

            Console.ReadLine();
        }
    }
}
