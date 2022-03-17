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
            var one = CurrencyCollection.Copper.X(150);
            var two = CurrencyCollection.Gold.X(2);
            int remainder = one.SubstractRounded(two);

            CharacterContext context = new CharacterContext();
            context.AddLevel(EClass.Bard);

            List<EquipmentToChoose> equipToChoose = context.Character.Inventory.EquipmentToChoose;

            DiceRoll cashRoll = context.SwitchStartingEquipmentToGold();


            context.Character.Inventory.Currency.AddCurrency(CurrencyCollection.Gold.X(11));
            context.Character.Inventory.Currency.AddCurrency(CurrencyCollection.Silver.X(17));
            context.Character.Inventory.Currency.AddCurrency(CurrencyCollection.Copper.X(353));

            Currency toSubstract = CurrencyCollection.Copper.X(353);
            int before = context.Character.Inventory.Currency.Sum(c => c.Count * c.ConversionFactor);
            context.Character.Inventory.Currency.SpendWithExchange(toSubstract, true);
            int after = context.Character.Inventory.Currency.Sum(c => c.Count * c.ConversionFactor);
            bool valid = before - after == toSubstract.Count * toSubstract.ConversionFactor;


            List<Currency> c = context.Character.Inventory.Currency;
            string output = $"pp: {c[4].Count}    gp: {c[3].Count}    ep: {c[2].Count}    sp: {c[1].Count}    cp: {c[0].Count}";

            Console.ReadLine();
        }
    }
}
