using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Static
{
    public class CurrencyCollection : StaticCollectionBase<CurrencyCollection, Currency>
    {
        public static Currency Copper = new Currency
        {
            Name = new LocalizedString { EN = "Copper", RU = "Медь" },
            Description = new LocalizedString { EN = "Copper piece (cp)", RU = "Медная монета (мм)" },
            ConversionFactor = 1
        };

        public static Currency Silver = new Currency
        {
            Name = new LocalizedString { EN = "Silver", RU = "Серебро" },
            Description = new LocalizedString { EN = "Silver piece (sp)", RU = "Серебряная монета (см)" },
            ConversionFactor = 10
        };

        public static Currency Electrum = new Currency
        {
            Name = new LocalizedString { EN = "Electrum", RU = "Электрум" },
            Description = new LocalizedString { EN = "Electrum piece (ep)", RU = "Электрумовая монета (эм)" },
            ConversionFactor = 50
        };

        public static Currency Gold = new Currency
        {
            Name = new LocalizedString { EN = "Gold", RU = "Золото" },
            Description = new LocalizedString { EN = "Gold piece (gp)", RU = "Золотая монета (зм)" },
            ConversionFactor = 100
        };

        public static Currency Platinum = new Currency
        {
            Name = new LocalizedString { EN = "Platinum", RU = "Платина" },
            Description = new LocalizedString { EN = "Platinum piece (pp)", RU = "Платиновая монета (пм)" },
            ConversionFactor = 1000
        };
    }
}
