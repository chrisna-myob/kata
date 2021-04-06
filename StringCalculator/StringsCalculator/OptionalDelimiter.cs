using System.Text.RegularExpressions;
using System.Linq;
using System;

namespace Strings.Calculator
{
    public class OptionalDelimiter : IDelimiter
    {
        private string _regex;
        public string[] GetDelimiters(string number)
        {
            var match = Regex.Matches(number, _regex);

            var delimiterArray = match.Select(m => m.Groups[1].Value).ToArray();

            return delimiterArray;
        }

        public OptionalDelimiter(string regex)
        {
            _regex = regex;
        }
    }
}
