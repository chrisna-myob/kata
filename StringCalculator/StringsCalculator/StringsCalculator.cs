using System.Text.RegularExpressions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Strings.Calculator
{

    public class StringsCalculator
    {
        public int Add(string number) {
            if (String.IsNullOrWhiteSpace(number)) {
                return 0;
            }

            var numbers = GetNumbersArray(number);

            if (numbers.Length > 1) return SumNumbers(numbers);
            return Int32.Parse(number);
        }

        public string[] GetNumbersArray(string number)
        {
            MatchCollection delimiter;
            string[] numbers;

            string pattern = @"\/\/(.*?)\n(.+)";
            
            MatchCollection matches = Regex.Matches(number, pattern);

            if (matches.Count != 0)
            {
                var delimiterValues = matches[0].Groups[1].Value;
                var sequence = matches[0].Groups[2].Value;

                if (delimiterValues.Length == 1) 
                {
                    delimiter = matches;

                } else {
                    delimiter = GetDelimiter(delimiterValues);
                }
                numbers = SplitStringWithDelimiter(delimiter, sequence);
            } else {
                numbers = number.Split(new char[] { ',', '\n'});
            }   

            return numbers;
        }

        public MatchCollection GetDelimiter(string number)
        {
            string invalidDelimiterPattern = @"\[(\d.*?|.*?\d)\]";
            MatchCollection invalidDelimiter = Regex.Matches(number, invalidDelimiterPattern);

            if (invalidDelimiter.Count > 0)
            {
                throw new ArgumentException("Invalid delimiter is used");
            }

            string delimiterGroup = @"\/\/(.*?)\n";
            MatchCollection delimiterValues = Regex.Matches(number, delimiterGroup);

            string delimiterPattern = @"\[(.*?)\]";
            MatchCollection delimiterBrackets = Regex.Matches(number, delimiterPattern);

            if (delimiterBrackets.Count > 0) {
                return delimiterBrackets;  
            } 

            return delimiterValues;
        }

        public string[] SplitStringWithDelimiter(MatchCollection matches, string number)
        {
            var multipleDelimiters = matches.Select(m => m.Groups[1].Value).ToArray();

            return number.Split(multipleDelimiters, StringSplitOptions.None);
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
            if (_negativeNumbers.Count > 0) 
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", _negativeNumbers.ToArray())}");
            }

        }     
    }
}
