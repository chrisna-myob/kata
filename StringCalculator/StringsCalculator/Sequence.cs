using System;

namespace Strings.Calculator
{
    public class Sequence
    {
        private string _numberPattern;

        private string _delimiterPattern;

        public string DelimiterPattern => _delimiterPattern;

        public string NumberString => _numberPattern;

        public Sequence(string numbers, string delimiterPattern = null)
        {
            _numberPattern = numbers;
            _delimiterPattern = delimiterPattern;
        }

    }
}