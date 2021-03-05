using System;

namespace Fizz.Buzz
{
    public class FizzBuzz
    {
        public string Process(int number) {
            if (number%3 == 0 && number%5 == 0) {
                return "FizzBuzz";
            }
            if (number%5 == 0) {
                return "Buzz";
            }
            if (number%3 == 0) {
                return "Fizz";
            }
            return number.ToString();
        }

        static void Main(string[] args)
        {
            var fizzBuzz = new FizzBuzz();
            for(int i = 1; i <= 100; i++) {
                Console.WriteLine(fizzBuzz.Process(i));
            }

        }
    }
}
