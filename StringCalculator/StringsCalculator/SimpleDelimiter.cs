using System.Text.RegularExpressions;
using System;

namespace Strings.Calculator
{
    public class SimpleDelimiter : IDelimiter
    {
        private string _regex;
        public string[] GetDelimiters(string number)
        {
            return new string[] { ",", "\n" };
        }

        public SimpleDelimiter(string regex)
        {
            _regex = regex;
        }

    }
}
