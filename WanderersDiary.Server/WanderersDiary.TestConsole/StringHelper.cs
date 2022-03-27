using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WanderersDiary.TestConsole
{
    public static class StringHelper
    {
        public static string GetBetweenThe(this string source, string left, string right, string center = ".*?")
        {
            Match match = Regex.Match(source, @$"({left})({center})({right})");

            return match.Groups[2].ToString();
        }

        public static List<string> GetAllBetweenThe(this string source, string left, string right, string center = ".*?")
        {
            MatchCollection matches = Regex.Matches(source, @$"({left})({center})({right})");

            return matches.Select(m => m.Groups[2].ToString()).ToList();
        }

        public static string GetInline(this string source)
        {
            return source.Replace("\n", "").Replace("\t", "");
        }
    }
}
