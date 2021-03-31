using System;
using Xunit;
using TicTacToe;

namespace TicTacToe.Tests
{
    public class CellTests
    {
        [Fact]
        public void IsAvailable_InputDotCharacter_ReturnTrue()
        {
            var cell = new Cell('.');

            Assert.True(cell.IsAvailable());
        }

        [Theory]
        [InlineData('X')]
        [InlineData(' ')]
        public void IsAvailable_InputIsNotDotCharacter_ReturnFalse(char character)
        {
            var cell = new Cell(character);

            Assert.False(cell.IsAvailable());
        }
        
    }
}
