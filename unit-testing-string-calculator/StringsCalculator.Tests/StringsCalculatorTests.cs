using System;
using Xunit;
using Strings.Calculator;

namespace Strings.Calculator.Tests
{
    public class StringsCalculatorTests
    {
        StringsCalculator stringCalculator = new StringsCalculator();

        [Fact]
        public void Should_Return_Zero_When_Input_String()
        {
            var result = stringCalculator.Add("");

            Assert.Equal(0, result);
        }

        [Fact]
        public void Should_Return_Integer_One_When_Input_String_One()
        {
            var result = stringCalculator.Add("1");

            Assert.Equal(1, result);
        }

        [Fact]
        public void Should_Return_Sum_When_Input_Two_String_Numbers()
        {
            var result = stringCalculator.Add("1,2");

            Assert.Equal(3, result);
        }

        [Fact]
        public void Should_Return_Sum_When_Input_Multiple_String_Numbers()
        {
            var result = stringCalculator.Add("1,2,3");

            Assert.Equal(6, result);
        }

        [Fact]
        public void Should_Return_Sum_When_Input_Includes_NewLine()
        {
            var result = stringCalculator.Add("1,2\n3");

            Assert.Equal(6, result);
        }

        [Fact]
        public void Should_Return_Sum_When_Input_Includes_NewLine()
        {
            var result = stringCalculator.Add("1,\n");

            Assert.Equal(6, result);
        }

        
    }
}
