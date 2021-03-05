using Xunit;
using Fizz.Buzz;

namespace Fizz.Buzz.Tests
{
    public class FizzBuzzTesting
    {

        [Fact]
        public void Should_Return_String_One_When_Input_One()
        {
            var fizzbuzz = new FizzBuzz();

            string actual = fizzbuzz.Process(1);

            Assert.Equal("1", actual);

        }

        [Fact]
        public void Should_Return_String_Fizz_When_Input_Three() {
            var fizzbuzz = new FizzBuzz();

            string actual = fizzbuzz.Process(3);

            Assert.Equal("Fizz", actual);
        }

        [Fact]
        public void Should_Return_String_Fizz_When_Input_Multiple_Of_Three() {
            var fizzbuzz = new FizzBuzz();

            string actual = fizzbuzz.Process(27);

            Assert.Equal("Fizz", actual);
        }

        [Fact]
        public void Should_Return_String_Buzz_When_Input_Five() {
            var fizzbuzz = new FizzBuzz();

            string actual = fizzbuzz.Process(5);

            Assert.Equal("Buzz", actual);
        }

        [Fact]
        public void Should_Return_String_Fizz_When_Input_Multiple_Of_Five() {
            var fizzbuzz = new FizzBuzz();

            string actual = fizzbuzz.Process(50);

            Assert.Equal("Buzz", actual);
        }

        [Fact]
        public void Should_Return_String_FizzBuzz_When_Input_Fifteen() {
            var fizzbuzz = new FizzBuzz();

            string actual = fizzbuzz.Process(15);

            Assert.Equal("FizzBuzz", actual);
        }

        [Fact]
        public void Should_Return_String_FizzBuzz_When_Input_Multiple_Of_Three_And_Five() {
            var fizzbuzz = new FizzBuzz();

            string actual = fizzbuzz.Process(75);

            Assert.Equal("FizzBuzz", actual);
        }
    }

    
}