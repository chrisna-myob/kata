using System.Text.RegularExpressions;
using System;

namespace Strings.Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StringsCalculator stringCalculator = new StringsCalculator();

            Console.WriteLine(stringCalculator.Add("//;\n1;2"));

        }
    }
}
