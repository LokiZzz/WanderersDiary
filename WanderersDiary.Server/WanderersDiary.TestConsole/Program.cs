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
            CharacterContext context = new CharacterContext();
            context.AddLevel(EClass.Bard);

            List<EquipmentToChoose> equipToChoose = context.Character.Inventory.EquipmentToChoose;

            DiceRoll cashRoll = context.SwitchStartingEquipmentToGold();


            context.Character.Inventory.Currency.AddCurrency(CurrencyCollection.Gold.X(4));
            context.Character.Inventory.Currency.AddCurrency(CurrencyCollection.Silver.X(9));
            context.Character.Inventory.Currency.AddCurrency(CurrencyCollection.Copper.X(30));

            context.Character.Inventory.Currency.AddCurrency(CurrencyCollection.Gold.X(5));

            context.Character.Inventory.Currency.SpendWithExchange(CurrencyCollection.Silver.X(19));


            Console.ReadLine();
        }
    }
}
