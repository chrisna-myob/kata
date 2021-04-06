using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

namespace Strings.Calculator
{

    public class StringsCalculator
    {
        private const string OPTIONAL_DELIMITER = "//";
        private const string NEWLINE = "\n";
        private IDelimiter _delimiter;
        private Sequence _sequence;
        
        public int Add(string number) {
            if (String.IsNullOrWhiteSpace(number)) {
                return 0;
            }

            CheckInvalidInputs(number);

            SeparateDelimiterAndNumbers(number);

            SetDelimiter();

            var delimiters = _delimiter.GetDelimiters(_sequence.DelimiterString);
            var numbers = _sequence.NumberString.Split(delimiters, StringSplitOptions.None);

            if (numbers.Length > 1) return SumNumbers(numbers);
            else return Int32.Parse(number);
        }

        public void CheckInvalidInputs(string number)
        {
            if (number.StartsWith(OPTIONAL_DELIMITER) && !number.Contains(NEWLINE))
            {
                throw new ArgumentException("Invalid delimiter is used");
            }
            string invalidDelimiterRegex = @"\/\/\[(\d.*?|.*?\d)\].+|\/\/\[\/\/.*]\n";
            MatchCollection invalidDelimiter = Regex.Matches(number, invalidDelimiterRegex);
            if (invalidDelimiter.Count > 0)
            {
                throw new ArgumentException("Invalid delimiter is used");
            }
        }

        public void SeparateDelimiterAndNumbers(string number)
        {
            var separateDelimeterAndNumbersRegex = @"(\/\/.+\n)(.+)";
            var matches = Regex.Matches(number, separateDelimeterAndNumbersRegex);
            if (matches.Count != 0)
            {
                var delimiterValues = matches[0].Groups[1].Value;
                var numberString = matches[0].Groups[2].Value;

                _sequence = new Sequence(numberString, delimiterValues);
                
            } else {
                _sequence = new Sequence(number, null);
            }   
        }

        public void SetDelimiter()
        {
            if (_sequence.DelimiterString == null)
            {
                _delimiter = new SimpleDelimiter("");
            } else {
                string bracketCheckRegex = @"\[.+\]";
                var matches = Regex.Matches(_sequence.DelimiterString, bracketCheckRegex);
                _delimiter = (matches.Count == 0 ? new OptionalDelimiter(@"\/\/(.*?)\n") : new OptionalDelimiter(@"\[(.*?)\]|\/\/(.)\n"));
            }
        }

        public int SumNumbers(string[] numbers)
        {
            List<int> _negativeNumbers = new List<int>();
            var sum = 0;
            foreach(string num in numbers) {
                var n = Int32.Parse(num);
                if (n < 0) {
                    _negativeNumbers.Add(n);
                } else if (n < 1000) {
                    sum += Int32.Parse(num);
                }
            }

            ThrowNegativeNumbersException(_negativeNumbers);

            return sum;
        }

        public void ThrowNegativeNumbersException(List<int> _negativeNumbers)
        {
            if (_negativeNumbers.Count > 0)  throw new ArgumentException($"Negatives not allowed: {string.Join(", ", _negativeNumbers.ToArray())}");

        }     
    }
}
