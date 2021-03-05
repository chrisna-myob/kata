using System;
using System.Collections.Generic;

namespace ABC
{
    public class ABCClass
    {
        public bool can_make_word(string word)
        {
            if (String.IsNullOrWhiteSpace(word)) return false;

            word = word.ToUpper();
            
            List<string> blocks = new List<string> {
                "BO", "XK", "DQ", "CP", "NA", "GT", "RE", "TG", "QD", "FS", "JW", "HU", "VI", "AN", "OB", "ER", "FS", "LY", "PC", "ZM"
            };

            int removedBlocks = 0;
            foreach(char character in word) {
                foreach(string block in blocks.ToArray()) {
                    if (block.IndexOf(character) != -1) {
                        blocks.Remove(block);
                        removedBlocks++;
                        break;
                    }
                }
            }

            if (removedBlocks == word.Length) return true;
            else return false;

        }

    }
}