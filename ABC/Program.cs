using System;
using System.Collections.Generic;

namespace ABC
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "A", "BARK", "BOOK", "TREAT", "COMMON", "SQUAD", "CONFUSE" };

            foreach(string word in words) {
                Console.WriteLine(can_make_word(word));
            }

        }

        public static string can_make_word(string word) 
        {
            if (String.IsNullOrEmpty(word)) {
                return "False";
            }

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

            if (removedBlocks == word.Length) {
                return "True";
            } else {
                return "False";
            }
            
        }
    }
}
