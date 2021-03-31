using System;
using Xunit;
using TicTacToe;

namespace TicTacToe.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_InputCharacterXAndInteger1_ReturnCharacterXAndNumber1()
        {
            var person = new Player('X', 1);

            Assert.Equal('X', person.Character);
            Assert.Equal(1, person.Number);
        }
    }
}
