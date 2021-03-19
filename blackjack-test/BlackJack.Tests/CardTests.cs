using System;
using Xunit;
using BlackJack;

namespace BlackJack.Tests
{
    public class CardTests
    {

        [Theory]
        [InlineData(Suit.Heart, Value.Two, "[2, 'HEART']")]
        [InlineData(Suit.Heart, Value.Ace, "['ACE', 'HEART']")]
        public void Card_InputSuitEnumValueAndValueEnumValue_ReturnFormattedString(Suit suit, Value value, string expected)
        {
            var card = new Card(suit, value);

            var actual = card.ToString();

            Assert.Equal(expected, actual);

        }
    }
}