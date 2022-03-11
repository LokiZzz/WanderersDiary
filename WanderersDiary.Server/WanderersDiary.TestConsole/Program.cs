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

namespace WanderersDiary.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileString = File.ReadAllText("EQUIPMENT.dtn");

            Root root = JsonConvert.DeserializeObject<Root>(fileString);
            List<ItemsList> items = root.itemsList.Where(i => i.en.type != "Armor" && i.en.type != "weapon").ToList();

            string csStaticFields = GetCSStaticFields(items);

            Console.WriteLine(ParsingHelper.GetStaticString("ItemName", "Item name", "Item name ru", "Desc en", "Desc ru", "0.1", "13", "EEnum.ItemType"));

            Console.ReadLine();
        }

        private static string GetCSStaticFields(List<ItemsList> items)
        {
            string result = string.Empty;

            foreach(ItemsList item in items)
            {
                string fieldName = GetItemFieldName(item.en.name);
                string price = GetPrice(item.en.coast);
                string weight = GetWeight(item.en.weight);
                string type = item.en.type.ToType().ToFullString();

                result += ParsingHelper.GetStaticString(fieldName,
                    item.en.name, item.ru.name,
                    item.en.text, item.ru.text,
                    price, weight, type
                );

                result += Environment.NewLine + Environment.NewLine;
            }

            return result;
        }

        private static string GetWeight(string weight)
        {
            if (weight.Equals("1/2")) return "0.5";
            if (weight.Equals("1/4")) return "0.25";
            if (weight.Equals("1/8")) return "0.125";
            if (string.IsNullOrEmpty(weight)) return "0";

            if (decimal.TryParse(weight, out decimal output))
            {
                return output.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                return string.Empty;
            }
        }

        public enum ECoin { Gp = 1, Sp = 2, Cp = 3 }

        private static string GetPrice(string price)
        {
            ECoin coin = ECoin.Gp;
            if (price.Contains("sp")) coin = ECoin.Sp;
            if (price.Contains("cp")) coin = ECoin.Cp;

            price = price.Replace(" ", string.Empty);
            price = price.Replace("gp", string.Empty);
            price = price.Replace("sp", string.Empty);
            price = price.Replace("cp", string.Empty);

            if (decimal.TryParse(price, out decimal output))
            {
                if (coin == ECoin.Sp) output = output / 10;
                if (coin == ECoin.Cp) output = output / 100;

                return output.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                return string.Empty;
            }
        }

        private static string GetItemFieldName(string name)
        {
            string result = string.Empty;

            name = name.Replace("(", string.Empty);
            name = name.Replace(")", string.Empty);
            name = name.Replace(",", string.Empty);
            name = name.Replace("'", string.Empty);
            name = name.Replace("-", string.Empty);

            string[] splitted = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            foreach(string item in splitted)
            {
                string itemCopy = item.ToLower();
                itemCopy = char.ToUpperInvariant(itemCopy[0]) + itemCopy.Substring(1);

                result += itemCopy;
            }

            return result;
        }
    }
}
