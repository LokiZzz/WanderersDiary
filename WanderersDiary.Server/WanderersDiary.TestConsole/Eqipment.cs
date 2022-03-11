using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.CharacterManagement.Models;

namespace WanderersDiary.TestConsole
{
    public static class ParsingHelper
    {
        public static string GetCSStaticFields(List<ItemsList> items)
        {
            string result = string.Empty;

            foreach (ItemsList item in items)
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

            foreach (string item in splitted)
            {
                string itemCopy = item.ToLower();
                itemCopy = char.ToUpperInvariant(itemCopy[0]) + itemCopy.Substring(1);

                result += itemCopy;
            }

            return result;
        }

        public static string GetStaticString(string itemName, string enName, string ruName, string enDesc, string ruDesc, string price, string weight, string type)
        {
            string result = string.Empty;

            result += @$"public static EquipmentItem {itemName} = new EquipmentItem" + Environment.NewLine;
            result += @$"{{" + Environment.NewLine;
            result += @$"    Name = new LocalizedString {{ EN = ""{enName}"", RU = ""{ruName}"" }}," + Environment.NewLine;

            if (!string.IsNullOrEmpty(enDesc) || !string.IsNullOrEmpty(ruDesc))
            {
                result += @$"    Description = new LocalizedString {{" + Environment.NewLine;
                result += @$"       EN = ""{enDesc}""," + Environment.NewLine;
                result += @$"       RU = ""{ruDesc}""" + Environment.NewLine;
                result += @$"    }}," + Environment.NewLine;
            }

            result += @$"    Price = {price}m, Weight = {weight}m, Type = {type}" + Environment.NewLine;
            result += @$"}};";

            return result;
        }
    }

    public static class EqExtension
    {
        public static EEquipmentType ToType(this string type)
        {
            type = type.Replace(" ", string.Empty);
            type = type.ToLowerInvariant();

            switch (type)
            {
                case "arcanefocus": return EEquipmentType.ArcaneFocus;
                case "druidicfocus": return EEquipmentType.DruidicFocus;
                case "hollysymbol": return EEquipmentType.HolySymbol;
                case "hollysimbol": return EEquipmentType.HolySymbol;
                case "ammunition": return EEquipmentType.Ammunition;
                case "camp": return EEquipmentType.Camp;
                case "clothes": return EEquipmentType.Clothes;
                case "consumables": return EEquipmentType.Consumable;
                case "container": return EEquipmentType.Container;
                case "gear": return EEquipmentType.Gear;
                case "kit": return EEquipmentType.Kit;
                case "tool": return EEquipmentType.Tool;

                default: throw new ArgumentException("Wrong type!");
            }
        }

        public static string ToFullString(this EEquipmentType type) => $"EEquipmentType.{type.ToString("G")}";
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class En
    {
        public string title { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string typeAdditions { get; set; }
        public int rarity { get; set; }
        public string text { get; set; }
        public string coast { get; set; }
        public string source { get; set; }
        public string img { get; set; }
        public string ac { get; set; }
        public bool stealthDis { get; set; }
        public string weight { get; set; }
        public string damageVal { get; set; }
        public string damageType { get; set; }
        public List<string> props { get; set; }
    }

    public class Ru
    {
        public string title { get; set; }
        public string gender { get; set; }
        public string he { get; set; }
        public string she { get; set; }
        public string it { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public string nic { get; set; }
    }

    public class Text
    {
        public En en { get; set; }
        public Ru ru { get; set; }
    }

    public class PHB
    {
        public Text text { get; set; }
    }

    public class SourceList
    {
        public PHB PHB { get; set; }
    }

    public class Armor
    {
        public Text text { get; set; }
        public List<string> subTypes { get; set; }
        public string img { get; set; }
    }

    public class Weapon
    {
        public Text text { get; set; }
        public List<string> subTypes { get; set; }
        public string img { get; set; }
    }

    public class Ammunition
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class Consumables
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class Kit
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class Tool
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class Gear
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class Container
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class ArcaneFocus
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class DruidicFocus
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class HollySimbol
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class Clothes
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class Camp
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class TypeList
    {
        public Armor armor { get; set; }
        public Weapon weapon { get; set; }
        public Ammunition ammunition { get; set; }
        public Consumables consumables { get; set; }
        public Kit kit { get; set; }
        public Tool tool { get; set; }
        public Gear gear { get; set; }
        public Container container { get; set; }

        [JsonProperty("arcane focus")]
        public ArcaneFocus ArcaneFocus { get; set; }

        [JsonProperty("druidic focus")]
        public DruidicFocus DruidicFocus { get; set; }

        [JsonProperty("holly simbol")]
        public HollySimbol HollySimbol { get; set; }
        public Clothes clothes { get; set; }
        public Camp camp { get; set; }
    }

    public class Light
    {
        public Text text { get; set; }
    }

    public class Medium
    {
        public Text text { get; set; }
    }

    public class Heavy
    {
        public Text text { get; set; }
    }

    public class Simple
    {
        public Text text { get; set; }
    }

    public class Shield
    {
        public Text text { get; set; }
    }

    public class Melee
    {
        public Text text { get; set; }
    }

    public class Ranged
    {
        public Text text { get; set; }
    }

    public class Martial
    {
        public Text text { get; set; }
    }

    public class TypeAddList
    {
        public Light light { get; set; }
        public Medium medium { get; set; }
        public Heavy heavy { get; set; }
        public Simple simple { get; set; }
        public Shield shield { get; set; }
        public Melee melee { get; set; }
        public Ranged ranged { get; set; }
        public Martial martial { get; set; }
    }

    public class Piercing
    {
        public Text text { get; set; }
    }

    public class Bludgeoning
    {
        public Text text { get; set; }
    }

    public class Slashing
    {
        public Text text { get; set; }
    }

    public class TypeDamagemList
    {
        public Piercing piercing { get; set; }
        public Bludgeoning bludgeoning { get; set; }
        public Slashing slashing { get; set; }
    }

    public class DexModifier
    {
        public Text text { get; set; }
    }

    public class Max
    {
        public Text text { get; set; }
    }

    public class AcList
    {
        [JsonProperty("dex modifier")]
        public DexModifier DexModifier { get; set; }
        public Max max { get; set; }
    }

    public class Versatile
    {
        public Text text { get; set; }
    }

    public class Thrown
    {
        public Text text { get; set; }
    }

    public class Range
    {
        public Text text { get; set; }
    }

    public class TwoHanded
    {
        public Text text { get; set; }
    }

    public class Finesse
    {
        public Text text { get; set; }
    }

    public class Reach
    {
        public Text text { get; set; }
    }

    public class Loading
    {
        public Text text { get; set; }
    }

    public class Special
    {
        public Text text { get; set; }
    }

    public class WeaponPropsList
    {
        public Light light { get; set; }
        public Heavy heavy { get; set; }
        public Versatile versatile { get; set; }
        public Thrown thrown { get; set; }
        public Range range { get; set; }

        [JsonProperty("two-handed")]
        public TwoHanded TwoHanded { get; set; }
        public Finesse finesse { get; set; }
        public Reach reach { get; set; }
        public Ammunition ammunition { get; set; }
        public Loading loading { get; set; }
        public Special special { get; set; }
    }

    public class ItemsList
    {
        public En en { get; set; }
        public Ru ru { get; set; }
    }

    public class Root
    {
        public SourceList sourceList { get; set; }
        public TypeList typeList { get; set; }
        public TypeAddList typeAddList { get; set; }
        public TypeDamagemList typeDamagemList { get; set; }
        public AcList acList { get; set; }
        public WeaponPropsList weaponPropsList { get; set; }
        public List<ItemsList> itemsList { get; set; }
    }
}
