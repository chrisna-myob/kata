using System;
using Xunit;
using Strings.Calculator;

namespace Strings.Calculator.Tests
{
    public class DelimiterTests
    {
        [Fact]
        public void GetDelimiter_InputSimpleDelimiter_ReturnStringArrayWithCommaAndNewline()
        {
            var expected = new string[] { ",", "\n" };
            var simpleDelimiter = new SimpleDelimiter("");

            var actual = simpleDelimiter.GetDelimiters("1,2\n3");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetDelimiter_InputSingleDelimiter_ReturnStringArrayWithSingleDelimiter()
        {
            string[] expected = { ";" };
            var singleDelimiter = new OptionalDelimiter(@"\/\/(.*?)\n");

            var actual = singleDelimiter.GetDelimiters("//;\n1;2");

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("//[***]\n1***2***3", new string[] { "***" })]
        [InlineData("//[*][%]\n1*2%3", new string[] { "*", "%" })]
        [InlineData("//[*1*][%]\n1*1*2%3", new string[] { "*1*", "%" })]
        public void GetDelimiter_InputMultipleCharacterSingleDelimiter_ReturnStringArrayWithMultipleCharacterSingleDelimiter(string sequence, string[] expected)
        {
            var singleDelimiter = new OptionalDelimiter(@"\[(.*?)\]|\/\/(.)\n");

            var actual = singleDelimiter.GetDelimiters(sequence);

            Assert.Equal(expected, actual);
        }
    }
}
