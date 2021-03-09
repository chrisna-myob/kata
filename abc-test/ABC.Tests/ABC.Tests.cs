using Xunit;
using ABC;
using System;

namespace ABC.Tests
{
    public class BlockTests
    {
        [Fact]
        public void BlockObject_InputIsAAndB_ReturnFirstLetterA()
        {
            var block = new Block('A', 'B');

            Assert.Equal('A', block.FirstLetter);
        }

        [Fact]
        public void BlockObject_InputIsAAndB_ReturnSecondLetterB()
        {
            var block = new Block('A', 'B');

            Assert.Equal('B', block.SecondLetter);
        }

        [Fact]
        public void BlockObject_InputIsaAndb_ReturnUppercaseFirstLetterA()
        {
            var block = new Block('A', 'B');

            Assert.Equal('A', block.FirstLetter);
        }

        [Fact]
        public void BlockObject_InputIsaAndb_ReturnUppercaseSecondLetterB()
        {
            var block = new Block('a', 'b');

            Assert.Equal('B', block.SecondLetter);
        }

        [Fact]
        public void ContainsLetter_InputIsA_ReturnTrue()
        {
            var block = new Block('A', 'B');

            var actual = block.ContainsLetter('A');

            Assert.True(actual);
        }

        [Fact]
        public void ContainsLetter_InputIsX_ReturnFalse()
        {
            var block = new Block('A', 'B');

            var actual = block.ContainsLetter('X');

            Assert.False(actual);
        }

        [Theory]
        [InlineData('1')]
        [InlineData('@')]
        public void ContainsLetter_InputInvalidCharacter_ReturnFalse(char input)
        {
            var block = new Block('A', 'B');

            var actual = block.ContainsLetter(input);

            Assert.False(actual);
        }
    }

    public class BlocksTest 
    {
        private readonly Blocks _blocks;

        public BlocksTest()
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
                                "(Z M)"
                            };

            _blocks = new Blocks();

            _blocks.MakeBlocks(stringBlocks); 
        }

        [Fact]
        public void CanMakeWord_InputEmptyString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _blocks.CanMakeWord(""));
        }


        [Theory]
        [InlineData("A")]
        [InlineData("BARK")]
        [InlineData("TREAT")]
        [InlineData("SQUAD")]
        [InlineData("CONFUSE")]
        public void CanMakeWord_InputWord_ReturnTrue(string input) {

            Assert.True(_blocks.CanMakeWord(input));

        }

        [Theory]
        [InlineData("BOOK")]
        [InlineData("COMMON")]
        public void CanMakeWord_InputWord_ReturnFalse(string input) {

            Assert.False(_blocks.CanMakeWord(input));

        }

    }
}