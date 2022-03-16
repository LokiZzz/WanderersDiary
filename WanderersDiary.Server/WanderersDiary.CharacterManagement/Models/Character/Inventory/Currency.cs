using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Currency
    {
        public LocalizedString Name { get; set; }

        public LocalizedString Description { get; set; }

        public int Count { get; set; }

        /// <summary>
        /// Multiplier to convert to copper from PHB
        /// CP = 1, SP = 10, EP = 50, GP = 100, PP = 1000
        /// </summary>
        public int CoversionFactor { get; set; }

        public EDefaultCurrency? DefaultCurrencyReference { get; set; }
    }

    public enum EDefaultCurrency
    {
        Copper = 1,
        Silver = 2,
        Electrum = 3,
        Gold = 4,
        Platinum = 5
    }
}
