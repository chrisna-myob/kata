using System;
using System.Collections.Generic;


namespace ABC
{
    public class BlockService {

        private List<Block> _blocks = new List<Block>();	

        private BlockBuilder blockBuilder = new BlockBuilder();

        public void MakeBlocks(string[] stringBlocks) {
            
            foreach(string b in stringBlocks) {
                _blocks.Add(blockBuilder.Build(b));
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
            foreach(var character in formattedWord) {
                foreach(var block in _blocks) {
                    if (block.ContainsLetter(character)) {
                        _blocks.Remove(block);
                        removedBlocks++;
                        break;
                    }
                }
            }

            if (removedBlocks == formattedWord.Length) return true;
            return false;

        }
    }
}