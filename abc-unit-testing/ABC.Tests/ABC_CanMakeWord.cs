using Xunit;
using ABC;

namespace ABC.Tests
{
    public class ABC_CanMakeWord
    {
        [Theory]
        [InlineData("A")]
        [InlineData("BARK")]
        [InlineData("TREAT")]
        [InlineData("SQUAD")]
        [InlineData("CONFUSE")]
        public void CanMakeWord_Input_ReturnTrue(string value)
        {
            var _abc = new ABCClass();
            var result = _abc.can_make_word(value);

            Assert.True(result);
        }

        [Theory]
        [InlineData("BOOK")]
        [InlineData("COMMON")]
        public void CanMakeWord_Input_ReturnFalse(string value)
        {
            var _abc = new ABCClass();
            var result = _abc.can_make_word(value);

            Assert.False(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void CanMakeWord_Empty_ReturnFalse(string value)
        {
            var _abc = new ABCClass();
            var result = _abc.can_make_word(value);

            Assert.False(result);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("baRk")]
        public void CanMakeWord_CaseInsensitive_ReturnTrue(string value)
        {
            var _abc = new ABCClass();
            var result = _abc.can_make_word(value);

            Assert.True(result);
        }

        [Theory]
        [InlineData("common")]
        public void CanMakeWord_CaseInsensitive_ReturnFalse(string value)
        {
            var _abc = new ABCClass();
            var result = _abc.can_make_word(value);

            Assert.False(result);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("!")]
        public void CanMakeWord_NotWord_ReturnFalse(string value)
        {
            var _abc = new ABCClass();
            var result = _abc.can_make_word(value);

            Assert.False(result);
        }
    }
}