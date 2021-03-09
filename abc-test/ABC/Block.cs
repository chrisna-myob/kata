using System;

namespace ABC
{
    public class Block {
        private char _firstLetter;
 
        private char _secondLetter;

        public char FirstLetter => _firstLetter;
        public char SecondLetter => _secondLetter;

        public Block(char letter1, char letter2) {
            _firstLetter = Char.ToUpper(letter1);
            _secondLetter = Char.ToUpper(letter2);
        }

        public bool ContainsLetter(char letter) {
            if (letter == this.FirstLetter || letter == this.SecondLetter) {
                return true;
            } else {
                return false;
            }
        }
    }
}