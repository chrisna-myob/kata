using System.Text.RegularExpressions;
using System;

namespace ABC
{
    public class BlockBuilder
    {
        const string LETTERS_WITHIN_BRACKET = @"(?<=\()[A-Za-z] [A-Za-z](?=\))";

        private void InvalidInputCheck(string input) {
            if (String.IsNullOrWhiteSpace(input)) {
                throw new ArgumentException("No letters given");
            }
        }

        public Block Build(string blockLetters) 
        {
            var stringLetters = Regex.Match(blockLetters, LETTERS_WITHIN_BRACKET).Value;

            InvalidInputCheck(stringLetters);

            var letters = stringLetters.Split(" ");

            var firstLetter = Char.Parse(letters[0]);
            var secondLetter = Char.Parse(letters[1]);

            return new Block(firstLetter, secondLetter);
        }
    }
}