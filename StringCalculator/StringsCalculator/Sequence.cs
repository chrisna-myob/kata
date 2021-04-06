using System;

namespace Strings.Calculator
{
    public class Sequence
    {
        private string _numberString;

        private string _delimiterString;

        public string DelimiterString => _delimiterString;

        public string NumberString => _numberString;

        public Sequence(string numbers, string delimiterPattern = null)
        {
            _numberString = numbers;
            _delimiterString = delimiterPattern;
        }

    }
}