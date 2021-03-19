using System.Reflection;
using Xunit;
using ABC;
using System;

namespace ABC.Tests
{
    public class BlockTests
    {
        private readonly Block _block;

        public BlockTests()
        {
            _block = new Block('A', 'B');
        }

        [Fact]
        public void BlockObject_InputIsAAndB_ReturnFirstLetterA()
        {
            Assert.Equal('A', _block.FirstLetter);
        }

        [Fact]
        public void Block_InputIsAAndB_ReturnSecondLetterB()
        {
            Assert.Equal('B', _block.SecondLetter);
        }

        [Fact]
        public void Block_InputIsaAndb_ReturnUppercaseFirstLetterA()
        {
            Assert.Equal('A', _block.FirstLetter);
        }

        [Fact]
        public void Block_InputIsaAndb_ReturnUppercaseSecondLetterB()
        {
            Assert.Equal('B', _block.SecondLetter);
        }

        [Fact]
        public void ContainsLetter_InputIsA_ReturnTrue()
        {
            Assert.True(_block.ContainsLetter('A'));
        }

        [Fact]
        public void ContainsLetter_InputIsX_ReturnFalse()
        {
            Assert.False(_block.ContainsLetter('X'));
        }

        [Theory]
        [InlineData('1')]
        [InlineData('@')]
        public void ContainsLetter_InputInvalidCharacter_ReturnFalse(char input)
        {
            Assert.False(_block.ContainsLetter(input));
        }
    }

    public class BlockBuilderTest
    {
        private readonly BlockBuilder _blockBuilder;

        private readonly Block _expectedBlock;

        public BlockBuilderTest()
        {
            _blockBuilder = new BlockBuilder();

            _expectedBlock = new Block('B', 'O');

        }

        [Fact]
        public void Build_InputStringOfTwoLetters_ReturnBlockFirstLetterB()
        {
            var _block = _blockBuilder.Build("(B O)");

            Assert.Equal(_expectedBlock.FirstLetter, _block.FirstLetter);
        }

        [Fact]
        public void Build_InputStringOfTwoLetters_ReturnBlockSecondLetterO() 
        {
            var _block = _blockBuilder.Build("(B O)");

            Assert.Equal(_expectedBlock.SecondLetter, _block.SecondLetter);

        }

        [Fact]
        public void Build_InputEmptyString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _blockBuilder.Build(""));
        }

        [Theory]
        [InlineData("(1 2)")]
        [InlineData("(@ e)")]
        [InlineData("(a B c)")]
        [InlineData("(A B C D)")]
        [InlineData("(AB CD)")]
        public void Build_InputInvalidLetters_ThrowsArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => _blockBuilder.Build(input));
        }
    }

    public class BlocksTest 
    {
        private readonly BlockService _blocks;

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
                                "(Z M)",
                                "(X W)"
                            };

            _blocks = new BlockService();

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
        [InlineData("EXK")]
        public void CanMakeWord_InputWord_ReturnTrue(string input) {
            Assert.True(_blocks.CanMakeWord(input));
        }

        [Theory]
        [InlineData("BOOK")]
        [InlineData("COMMON")]
        public void CanMakeWord_InputWord_ReturnFalse(string input) {
            Assert.False(_blocks.CanMakeWord(input));
        }

        [Fact]
        public void CanMakeWord_InputLowercaseWord_ReturnTrue() {
            Assert.True(_blocks.CanMakeWord("confuse"));
        }

        [Fact]
        public void CanMakeWord_InputLowercaseWord_ReturnFalse() {
            Assert.False(_blocks.CanMakeWord("common"));
        }

    }
}