using System;
using Xunit;
using TicTacToe;

namespace TicTacToe.Tests
{
    public class BoardTests
    {
        public readonly int BOARD_SIZE = 3;

        [Fact]
        public void MarkPlayersMove_InputString()
        {
            var board = new Board();
            board.MarkPlayersMove('X', new Coordinate(0,0));

            var actual = board.CellIsAvailable(0, 0);

            Assert.False(actual);
        }

        [Theory]
        [MemberData(nameof(TestDataGenerator.GetWinningCoordinatesFromDataGenerator), MemberType = typeof(TestDataGenerator))]
        public void GetWinnerCharacter_InputAllPossibleWinCoordinates_ReturnWinnerCharacter(Coordinate coordinate1, Coordinate coordinate2, Coordinate coordinate3)
        {
            var board = new Board();

            board.MarkPlayersMove('X', coordinate1);
            board.MarkPlayersMove('X', coordinate2);
            board.MarkPlayersMove('X', coordinate3);

            var actual = board.GetWinnerCharacter();

            Assert.Equal('X', actual);
        }

        [Fact]
        public void GetWinnerCharacter_InputNonWinCoordinate_ReturnNoWinner()
        {
            var expected = Char.MinValue;
            var board = new Board();

            board.MarkPlayersMove('X', new Coordinate(0,0));
            board.MarkPlayersMove('X', new Coordinate(2,0));
            board.MarkPlayersMove('X', new Coordinate(1,1));

            var actual = board.GetWinnerCharacter();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestDataGenerator.GetWinningCoordinatesFromDataGenerator), MemberType = typeof(TestDataGenerator))]
        public void HasWinner_InputAllPossibleWinCoordinates_ReturnTrue(Coordinate coordinate1, Coordinate coordinate2, Coordinate coordinate3)
        {
            var board = new Board();

            board.MarkPlayersMove('X', coordinate1);
            board.MarkPlayersMove('X', coordinate2);
            board.MarkPlayersMove('X', coordinate3);

            var actual = board.HasWinner();

            Assert.True(actual);
        }

        [Fact]
        public void HasWinner_InputNonWinCoordinates_ReturnFalse()
        {
            var board = new Board();

            board.MarkPlayersMove('X', new Coordinate(0,0));
            board.MarkPlayersMove('X', new Coordinate(2,0));
            board.MarkPlayersMove('X', new Coordinate(1,1));

            var actual = board.HasWinner();

            Assert.False(actual);
        }

        [Fact]
        public void CellIsAvailable_InputUsedCoordinates_ReturnFalse()
        {
            var board = new Board();
            board.MarkPlayersMove('X', new Coordinate(0,0));

            var actual = board.CellIsAvailable(0, 0);

            Assert.False(actual);
        }

        [Fact]
        public void CellIsAvailable_InputUnusedCoordinates_ReturnTrue()
        {
            var board = new Board();

            var actual = board.CellIsAvailable(0, 0);

            Assert.True(actual);
        }

        [Theory]
        [InlineData(5,4)]
        [InlineData(-1,-6)]
        public void CellIsAvailable_InputInvalidCoordinates_ReturnFalse(int x, int y)
        {
            var board = new Board();

            var actual = board.CellIsAvailable(x, y);

            Assert.False(actual);
        }

        [Fact]
        public void HasAcceptableMove_InputCoordinate_ReturnTrue()
        {
            var board = new Board();

            var actual = board.HasAcceptableMove(new Coordinate(1,1));

            Assert.True(actual);
        }

        [Fact]
        public void HasAcceptableMove_InputCoordinate_ReturnFalse()
        {
            var board = new Board();

            var actual = board.HasAcceptableMove(new Coordinate(3,4));

            Assert.False(actual);
        }

        [Fact]
        public void IsFull_InputFullBoard_ReturnTrue()
        {
            var board = new Board();
            for(int x = 0; x < BOARD_SIZE; x++)
            {
                for(int y = 0; y < BOARD_SIZE; y++)
                {
                    board.MarkPlayersMove('X', new Coordinate(x,y));
                }
            }

            var actual = board.IsFull();

            Assert.True(actual);
        }

        [Fact]
        public void IsFull_InputNonFilledBoard_ReturnFalse()
        {
            var board = new Board();

            var actual = board.IsFull();

            Assert.False(actual);
        }

        [Fact]
        public void IsFull_InputPartiallyFilledBoard_ReturnFalse()
        {
            var board = new Board();
            board.MarkPlayersMove('X', new Coordinate(0,0));
            board.MarkPlayersMove('0', new Coordinate(1,1));
            
            var actual = board.IsFull();

            Assert.False(actual);
        }
    
    }
}
