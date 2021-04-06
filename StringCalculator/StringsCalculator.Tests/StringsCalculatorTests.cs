using System;
using Xunit;
using Strings.Calculator;

namespace Strings.Calculator.Tests
{
    public class StringsCalculatorTests
    {
        StringsCalculator stringCalculator = new StringsCalculator();

        [Fact]
        public void Add_InputEmptyValue_ReturnZero()
        {
            var result = stringCalculator.Add("");

            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_InputStringOne_ReturnIntegerOne()
        {
            var result = stringCalculator.Add("1");

            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_InputStringWithTwoNumbersCommaSeparated_ReturnSumThree()
        {
            var result = stringCalculator.Add("1,2");

            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_InputStringMultipleNumbersCommaSeparated_ReturnSumSix()
        {
            var result = stringCalculator.Add("1,2,3");

            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_InputStringMultipleNumbersCommaAndNewlineSeparated_ReturnSumSix()
        { 
            var result = stringCalculator.Add("1,2\n3");

            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_InputStringAndSingleCharacterDelimiter_ReturnSumThree()
        {
            var result = stringCalculator.Add("//;\n1;2");

            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_InputNegativeNumbers_ThrowArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(() => stringCalculator.Add("-1,2,-3"));
            Assert.Equal("Negatives not allowed: -1, -3", exception.Message);
        }

        [Fact]
        public void Add_InputNumbersLargerThan1000_ReturnNumbersLessThan1000()
        {
            var result = stringCalculator.Add("1000,1001,2");

            Assert.Equal(2, result);
        }

        [Fact]
        public void Add_InputSingleDelimiterOfMultipleLength_ReturnSum6()
        {
            var result = stringCalculator.Add("//[***]\n1***2***3");

            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_InputMultipleSingleCharacterDelimiters_ReturnSum6()
        {
            var result = stringCalculator.Add("//[*][%]\n1*2%3");

            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_InputMultipleDelimitersWithLengthLargerThanOne_ReturnSum6()
        {
            var result = stringCalculator.Add("//[***][#][%]\n1***2#3%4");

            Assert.Equal(10, result);
        }
          
        [Theory]
        [InlineData("//[*1*][%]\n1*1*2%3")]
        [InlineData("//[*1**][%]\n1*1**2%3")]
        public void Add_InputMultipleDelimitersWithNumbersInMiddleOfDelimiter_ReturnSum6(string sequence)
        {
            var result = stringCalculator.Add(sequence);

            Assert.Equal(6, result);
        }

        [Theory]
        [InlineData("//;1;2;3")]
        [InlineData("//[1**][%]\n1*1*2%3")]
        [InlineData("//[**1][%]\n1*1**2%3")]
        public void Add_InputMultipleDelimitersWithNumbersOnEdgeOfDelimiter_ThrowException(string sequence)
        {
            var exception = Assert.Throws<ArgumentException>(() => stringCalculator.Add(sequence));
            Assert.Equal("Invalid delimiter is used", exception.Message);
        }

        [Fact]
        public void GetDelimiter_InputSimpleDelimiter_ReturnStringArrayWithCommaAndNewline()
        {
            var expected = new string[] { ",", "\n" };
            var simpleDelimiter = new SimpleDelimiter();

            var actual = simpleDelimiter.GetDelimiters("1,2\n3");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetDelimiter_InputSingleDelimiter_ReturnStringArrayWithSingleDelimiter()
        {
            string[] expected = { ";" };
            var singleDelimiter = new SingleDelimiter();

            var actual = singleDelimiter.GetDelimiters("//;\n1;2");

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("//[***]\n1***2***3", new string[] { "***" })]
        [InlineData("//[*][%]\n1*2%3", new string[] { "*", "%" })]
        [InlineData("//[*1*][%]\n1*1*2%3", new string[] { "*1*", "%" })]
        public void GetDelimiter_InputMultipleCharacterSingleDelimiter_ReturnStringArrayWithMultipleCharacterSingleDelimiter(string sequence, string[] expected)
        {
            var singleDelimiter = new BracketDelimiter();

            var actual = singleDelimiter.GetDelimiters(sequence);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sequence_ReturnNumberStringAndDelimiterPattern()
        {
            var sequence = new Sequence("1;2", "//;\n");

            Assert.Equal("1;2", sequence.NumberString);
            Assert.Equal("//;\n", sequence.DelimiterPattern);
        }

        [Fact]
        public void Sequence_ReturnNumberStringAndNull()
        {
            var sequence = new Sequence("1,2,3", null);

            Assert.Equal("1,2,3", sequence.NumberString);
            Assert.Null(sequence.DelimiterPattern);
        }

        [Fact]
        public void SumNumbers_InputStringArrayOfPositiveNumbers_ReturnSum()
        {
            string[] numbers = { "1", "2", "3" };
            
            var actual = stringCalculator.SumNumbers(numbers);

            Assert.Equal(6, actual);
        }

        [Fact]
        public void SumNumbers_InputStringArrayOfPositiveAndNegativeNumbers_ThrowArgumentException()
        {
            string[] numbers = { "-1", "2", "-3" };

            var exception = Assert.Throws<ArgumentException>(() => stringCalculator.SumNumbers(numbers));
            
            Assert.Equal("Negatives not allowed: -1, -3", exception.Message);
        }


    }
}
