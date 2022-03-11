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

            decimal sum = PackCollection.BurglarsPack.Items.Sum(i => i.Price * i.Quantity + i.Content.Sum(c => c.Price * c.Quantity)).Value;
            List<string> itemPrices = PackCollection.BurglarsPack.Items.Select(i => 
                $"{i.Name.RU}:\n\t\t{i.Price} x {i.Quantity} = {i.Price*i.Quantity}"
            ).ToList();

            itemPrices.ForEach(i => Console.WriteLine(i));

            Console.ReadLine();
        }

        
    }
}
