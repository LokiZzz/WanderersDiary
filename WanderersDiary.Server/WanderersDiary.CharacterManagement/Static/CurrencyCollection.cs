using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Static
{
    public class CurrencyCollection : StaticCollectionBase<CurrencyCollection, Currency>
    {
        public static Currency Copper => new Currency
        {
            Name = new LocalizedString { EN = "Copper", RU = "Медь" },
        }
    }
}
