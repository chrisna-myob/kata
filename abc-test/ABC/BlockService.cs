using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC
{
    public class BlockService {

        private List<Block> _sortedBlocks = new List<Block>();

        private List<Block> _usedBlocks = new List<Block>();

        private BlockBuilder blockBuilder = new BlockBuilder();

        public void MakeBlocks(string[] stringBlocks) {
            var makeBlocks = new List<Block>();
            
            foreach(string b in stringBlocks) {
                makeBlocks.Add(blockBuilder.Build(b));
            }    

            _sortedBlocks = makeBlocks.OrderBy(b => b.FirstLetter).ToList();

        }

        public List<Block> GetBlock()
        {
            return _sortedBlocks;
        }

        private string MakeWord(string input) {
            if (String.IsNullOrWhiteSpace(input)) {
                throw new ArgumentException("Invalid Word");
            }

            var word = String.Concat(input.OrderBy(character => character));

            return word.ToUpper();

        }

        public bool CanMakeWord(string word)
        {
            var sortedWord = MakeWord(word);

            foreach(var character in sortedWord) {
                foreach(var block in _sortedBlocks) {
                    if (block.ContainsLetter(character)) {
                        _usedBlocks.Add(block);
                        _sortedBlocks.Remove(block);
                        break;
                    }
                }
            }

            if (_usedBlocks.Count == sortedWord.Length) return true;
            return false;

        }
    }
}