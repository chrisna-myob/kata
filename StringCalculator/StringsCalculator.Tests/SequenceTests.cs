using System;
using Xunit;
using Strings.Calculator;

namespace Strings.Calculator.Tests
{
    public class SequenceTests
    {
        [Fact]
        public void Sequence_ReturnNumberStringAndDelimiterPattern()
        {
            var sequence = new Sequence("1;2", "//;\n");

            Assert.Equal("1;2", sequence.NumberString);
            Assert.Equal("//;\n", sequence.DelimiterString);
        }

        [Fact]
        public void Sequence_ReturnNumberStringAndNull()
        {
            var sequence = new Sequence("1,2,3", null);

            Assert.Equal("1,2,3", sequence.NumberString);
            Assert.Null(sequence.DelimiterString);
        }
    }
}
