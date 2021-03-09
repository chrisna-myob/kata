using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace ABC
{
    public class Blocks {

        private List<Block> _blocks = new List<Block>();	

        public void MakeBlocks(string[] stringBlocks) {
            foreach(string b in stringBlocks) {
                var stringLetters = Regex.Match(b, @"(?<=\().*?(?=\))").Value;
                var letters = stringLetters.Split(' '); 
                this._blocks.Add(new Block(Char.Parse(letters[0]), Char.Parse(letters[1])));
            }    
        }

        private void InvalidInputCheck(string input) {
            if (String.IsNullOrWhiteSpace(input)) {
                throw new ArgumentException("Invalid Word");
            }
        }

        public bool CanMakeWord(string word)
        {
            InvalidInputCheck(word);

            var formattedWord = word.ToUpper();

            var removedBlocks = 0;
            foreach(var character in word) {
                foreach(var block in _blocks) {
                    if (block.ContainsLetter(character)) {
                        _blocks.Remove(block);
                        removedBlocks++;
                        break;
                    }
                }
            }

            if (removedBlocks == word.Length) return true;
            return false;

        }
    }
}