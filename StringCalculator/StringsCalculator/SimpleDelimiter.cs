using System.Text.RegularExpressions;
using System;

namespace Strings.Calculator
{
    public class SimpleDelimiter : IDelimiter
    {
        public string[] GetDelimiters(string number)
        {
            return new string[] { ",", "\n" };
        }
    }
}
