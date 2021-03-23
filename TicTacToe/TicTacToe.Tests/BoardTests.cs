using System;
using Xunit;
using TicTacToe;

namespace TicTacToe.Tests
{
    public class BoardTests
    {
        [Theory]
        [InlineData(new int[] {0,0}, new int[] {0,1}, new int[] {0,2})]
        [InlineData(new int[] {1,0}, new int[] {1,1}, new int[] {1,2})]
        [InlineData(new int[] {2,0}, new int[] {2,1}, new int[] {2,2})]
        [InlineData(new int[] {0,0}, new int[] {1,0}, new int[] {2,0})]
        [InlineData(new int[] {0,1}, new int[] {1,1}, new int[] {2,1})]
        [InlineData(new int[] {0,2}, new int[] {1,2}, new int[] {2,2})]
        [InlineData(new int[] {0,0}, new int[] {1,1}, new int[] {2,2})]
        [InlineData(new int[] {2,0}, new int[] {1,1}, new int[] {0,2})]
        public void HasWon_InputAllPossibleWinCoordinates_ReturnTrue(int[] coordinate1, int[] coordinate2, int[] coordinate3)
        {
            var board = new Board();

            board.AddCharacterToBoard('X', coordinate1[0], coordinate1[1]);
            board.AddCharacterToBoard('X', coordinate2[0], coordinate2[1]);
            board.AddCharacterToBoard('X', coordinate3[0], coordinate3[1]);

            var actual = board.HasWon();

            Assert.True(actual);
        }

        [Fact]
        public void IsAvailable_InputUsedCoordinates_ReturnFalse()
        {
            var board = new Board();
            board.AddCharacterToBoard('X', 0, 0);

            var actual = board.IsAvailable(0, 0);

            Assert.False(actual);
        }

        [Fact]
        public void IsAvailable_InputUnusedCoordinates_ReturnTrue()
        {
            var board = new Board();

            var actual = board.IsAvailable(0, 0);

            Assert.True(actual);
        }

        [Theory]
        [InlineData(5,4)]
        [InlineData(-1,-6)]
        public void IsAvailable_InputInvalidCoordinates_ReturnFalse(int x, int y)
        {
            var board = new Board();

            var actual = board.IsAvailable(x, y);

            Assert.False(actual);
        }
    
    }
}
