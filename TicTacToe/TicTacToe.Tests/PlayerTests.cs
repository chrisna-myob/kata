using System;
using Xunit;
using TicTacToe;

namespace TicTacToe.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_InputCharXAndInteger1_ReturnCharacterX()
        {
            var person = new Player('X', 1);

            Assert.Equal('X', person.Character);
        }

        [Fact]
        public void Player_InputCharXAndInteger1_ReturnNumber1()
        {
            var person = new Player('X', 1);

            Assert.Equal(1, person.Number);
        }
    }
}
