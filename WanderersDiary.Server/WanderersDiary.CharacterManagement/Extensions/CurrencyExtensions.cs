using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Models;

namespace WanderersDiary.CharacterManagement
{
    public static class CurrencyExtensions
    {
        public static void AddCurrency(this List<Currency> thisCurrency, Currency currencyToAdd)
        {
            Currency currentCurrency = thisCurrency
                .FirstOrDefault(c => c.IsSame(currencyToAdd));

            if(currentCurrency == null)
            {
                thisCurrency.Add(currencyToAdd);
            }
            else
            {
                currentCurrency.AddRounded(currencyToAdd);
            }
        }

        public static bool SpendWithExchange(this List<Currency> thisCurrency, Currency currencyToSpend)
        {
            List<Currency> sortedCurrency = thisCurrency
                .Where(c => c.CoversionFactor >= currencyToSpend.CoversionFactor)
                .OrderBy(c => c.CoversionFactor)
                .ToList();

            foreach (Currency currency in sortedCurrency)
            {
                currency.SubstractRounded(currencyToSpend);

                if(currency.Count >= 0)
                {
                    return true;
                }
                else
                {
                    currencyToSpend.AddRounded(currency);
                    currency.Count = 0;
                }
            }

            return false;
        }

        public static bool SpendStrict(this List<Currency> thisCurrencyCollection, Currency currencyToSpend)
        {
            Currency currentCurrency = thisCurrencyCollection
                .FirstOrDefault(c => c.IsSame(currencyToSpend));

            if (currentCurrency == null || currentCurrency.Count < currencyToSpend.Count)
            {
                return false;
            }
            else
            {
                currentCurrency.Count -= currencyToSpend.Count;

                return true;
            }
        }

        public static void AddRounded(this Currency thisCurrency, Currency otherCurrency)
        {
            int converted = otherCurrency.Count * otherCurrency.CoversionFactor;

            thisCurrency.Count += converted / thisCurrency.CoversionFactor;
        }

        public static void SubstractRounded(this Currency thisCurrency, Currency otherCurrency)
        {
            int converted = otherCurrency.Count * otherCurrency.CoversionFactor;

            thisCurrency.Count -= converted / thisCurrency.CoversionFactor;
        }

        public static Currency X(this Currency thisCurrency, int X)
        {
            Currency result = thisCurrency.Copy();
            result.Count = X;

            return result;
        }

        public static bool IsSame(this Currency thisCurrency, Currency otherCurrency)
        {
            Currency thisCopy = thisCurrency.Copy();
            thisCopy.Count = 0;
            Currency otherCopy = otherCurrency.Copy();
            otherCopy.Count = 0;

            return Utility.IsEqual(thisCopy, otherCopy);
        }
    }
}
