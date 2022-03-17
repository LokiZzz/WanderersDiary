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

        public static bool SpendWithExchange(this List<Currency> thisCurrency, Currency currencyToSpend, bool saveLow = true)
        {
            Currency toSpend = currencyToSpend.Copy();

            if (toSpend.Count * toSpend.ConversionFactor > thisCurrency.Sum(c => c.Count * c.ConversionFactor))
            {
                return false;
            }

            List<Currency> sortedCurrency = saveLow
                ? thisCurrency.OrderByDescending(c => c.ConversionFactor).ToList()
                : thisCurrency.OrderBy(c => c.ConversionFactor).ToList();

            foreach (Currency currency in sortedCurrency)
            {
                if (currency.Count == 0) continue;

                int remainder = currency.SubstractRounded(toSpend);

                if(currency.Count < 0)
                {
                    if (toSpend.ConversionFactor <= currency.ConversionFactor)
                    {
                        toSpend.Count = -currency.Count * (currency.ConversionFactor / toSpend.ConversionFactor) + (-remainder);
                    }
                    else
                    {
                        toSpend = currency.Copy();
                        toSpend.Count = -toSpend.Count;
                    }

                    currency.Count = 0;
                }
                else
                {
                    Currency currentCurrency = sortedCurrency.FirstOrDefault(c => c.IsSame(toSpend));
                    currentCurrency.Count += remainder;

                    return true;
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

        /// <summary>
        /// Add currency, using rounded conversion and returns remainder of conversion.
        /// </summary>
        public static int AddRounded(this Currency thisCurrency, Currency otherCurrency)
        {
            int converted = otherCurrency.Count * otherCurrency.ConversionFactor;
            int remainder = converted % thisCurrency.ConversionFactor / otherCurrency.ConversionFactor;
            thisCurrency.Count += converted / thisCurrency.ConversionFactor;

            return remainder;
        }

        /// <summary>
        /// Substract currency, using rounded conversion and returns remainder of conversion.
        /// </summary>
        public static int SubstractRounded(this Currency thisCurrency, Currency otherCurrency)
        {
            if (thisCurrency.ConversionFactor == otherCurrency.ConversionFactor)
            {
                thisCurrency.Count -= otherCurrency.Count;

                return 0;
            }
            else
            {
                int convertedThis = thisCurrency.Count * thisCurrency.ConversionFactor;
                int convertedOther = otherCurrency.Count * otherCurrency.ConversionFactor;

                int nowThis = convertedThis - convertedOther;
                int remainder = (nowThis % thisCurrency.ConversionFactor) / otherCurrency.ConversionFactor;
                thisCurrency.Count = nowThis / thisCurrency.ConversionFactor;

                return remainder;
            }
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
