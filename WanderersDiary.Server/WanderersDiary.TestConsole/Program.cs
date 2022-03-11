using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using WanderersDiary.CharacterManagement;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Enums;
using WanderersDiary.CharacterManagement.Models.Utility;
using WanderersDiary.CharacterManagement.Static;

namespace WanderersDiary.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //string fileString = File.ReadAllText("EQUIPMENT.dtn");

            //Root root = JsonConvert.DeserializeObject<Root>(fileString);
            //List<ItemsList> items = root.itemsList.Where(i => i.en.type != "Armor" && i.en.type != "weapon").ToList();

            var tools = ToolsCollection.GetAll();

            Console.ReadLine();
        }

        
    }
}
