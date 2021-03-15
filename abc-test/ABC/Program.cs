using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stringBlocks = new[] {
                                "(B O)",
                                "(X K)",
                                "(D Q)",
                                "(C P)",
                                "(N A)",
                                "(G T)",
                                "(R E)",
                                "(T G)",
                                "(Q D)",
                                "(F S)",
                                "(J W)",
                                "(H U)",
                                "(V I)",
                                "(A N)",
                                "(O B)",
                                "(E R)",
                                "(F S)",
                                "(L Y)",
                                "(P C)",
                                "(Z M)",
                                "(X W)"
                            };

            var _blocks = new BlockService();

            _blocks.MakeBlocks(stringBlocks); 

            foreach(var b in _blocks.GetBlock()) {
                Console.WriteLine(b);
            }

        }
    }
}
