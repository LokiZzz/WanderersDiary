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
            CharacterContext context = new CharacterContext();
            context.AddLevel(EClass.Bard);

            var equipToChoose = context.Character.Inventory.EquipmentToChoose;

            Console.ReadLine();
        }

        
    }
}
