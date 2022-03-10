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
            List<ItemsList> items = root.itemsList.Where(i => i.en.type != "Armor" && i.en.type != "weapon").ToList();
            List<string> itemsNames = items.Select(i => i.ru.name).ToList();

            Console.ReadLine();
        }
    }
}
