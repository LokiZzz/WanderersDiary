using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.TestConsole
{
    public static class ParsingHelper
    {
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
}
