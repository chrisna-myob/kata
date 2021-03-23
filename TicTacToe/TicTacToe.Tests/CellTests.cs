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

        [Fact]
        public void IsAvailable_InputXCharacter_ReturnFalse()
        {
            var cell = new Cell('X');

            Assert.False(cell.IsAvailable());
        }
        
    }
}
