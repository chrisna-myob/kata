using System;

namespace Strings.Calculator
{
    public class StringsCalculator
    {
        public int Add(string number) {
            if (String.IsNullOrWhiteSpace(number)) {
                return 0;
            }

            char[] delimiterChars = { ',', '\n' };

            string[] numbers = number.Split(delimiterChars);

            if (numbers.Length > 1) {
                var sum = 0;
                foreach(string num in numbers) {
                    sum += Int32.Parse(num);
                }
                return sum;
            }
            
            return Int32.Parse(number);
            
        }
    }
}
