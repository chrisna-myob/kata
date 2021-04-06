using System.Text.RegularExpressions;
using System.Linq;
using System;

namespace Strings.Calculator
{
    public class SingleDelimiter : IDelimiter
    {
        public string[] GetDelimiters(string number)
        {
            var singleDelimiterRegex = @"\/\/(.*?)\n";

            var match = Regex.Matches(number, singleDelimiterRegex);

            var delimiterArray = match.Select(m => m.Groups[1].Value).ToArray();

            return delimiterArray;
        }
    }
}
