using System.Text.RegularExpressions;
using System;
using System.Linq;

namespace Strings.Calculator
{
    public class BracketDelimiter : IDelimiter
    {
        public string[] GetDelimiters(string number)
        {
            var singleDelimiterRegex = @"\[(.*?)\]|\/\/(.)\n";

            var match = Regex.Matches(number, singleDelimiterRegex);

            var delimiterArray = match.Select(m => m.Groups[1].Value).ToArray();

            return delimiterArray;
        }
    }
}
