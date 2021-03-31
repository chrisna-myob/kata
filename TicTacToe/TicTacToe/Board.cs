using System;
using TicTacToe;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        private const char NO_WINNER = Char.MinValue;
        private const int SIZE_OF_BOARD = 3;
        private Cell[,] _board;

        public Board()
        {
            MakeBoard();
        }

        private void MakeBoard()
        {
            _board = new Cell[SIZE_OF_BOARD, SIZE_OF_BOARD];
            for(int row = 0; row < SIZE_OF_BOARD; row++)
            {
                for (int column = 0; column < SIZE_OF_BOARD; column++)
                {
                    _board[row, column] = new Cell('.');
                }
            }
        }  
        public void MarkPlayersMove(char character, Coordinate coordinate)
        {
            _board[coordinate.X, coordinate.Y].Value = character;
        }
        public void PrintBoard()
        {
            for(int row = 0; row < SIZE_OF_BOARD; row++)
            {
                for (int column = 0; column < SIZE_OF_BOARD; column++)
                {
                    if (column + 1 == SIZE_OF_BOARD)
                    {
                        Console.WriteLine(_board[row, column].Value);
                    } else {
                        Console.Write(_board[row, column].Value);
                    }
                }
            }
            Console.WriteLine();
        }

        public bool CellIsAvailable(int x, int y)
        {
            if(x >= SIZE_OF_BOARD || y >= SIZE_OF_BOARD) return false;
            else if(x < 0 || y < 0) return false;
            return _board[x, y].IsAvailable();
        }

        private bool CellEquals(char cell1, char cell2, char cell3)
        {
            return (cell1 != '.' && cell1 == cell2 && cell2 == cell3);
        }

        private char GetHorizontalWinCharacter()
        {
            for(int row = 0; row < SIZE_OF_BOARD; row++)
            {
                if (CellEquals(_board[row, 0].Value, _board[row, 1].Value, _board[row, 2].Value)) return _board[row, 0].Value;
            }
            return NO_WINNER;
        }

        private char GetVerticalWinCharacter()
        {
            for(int column = 0; column < SIZE_OF_BOARD; column++)
            {
                if (CellEquals(_board[0, column].Value, _board[1, column].Value, _board[2, column].Value)) return _board[0, column].Value;
            }
            return NO_WINNER;
        }

        private char GetDiagonalWinCharacter()
        {
            if (CellEquals(_board[0, 0].Value, _board[1, 1].Value, _board[2, 2].Value)) return _board[0, 0].Value;
            if (CellEquals(_board[0, 2].Value, _board[1, 1].Value, _board[2, 0].Value)) return _board[2, 0].Value;
            return NO_WINNER;
        }

        public char GetWinnerCharacter()
        {
            if (GetHorizontalWinCharacter() != NO_WINNER) return GetHorizontalWinCharacter();
            if (GetVerticalWinCharacter() != NO_WINNER) return GetVerticalWinCharacter();
            if (GetDiagonalWinCharacter() != NO_WINNER) return GetDiagonalWinCharacter();
            return NO_WINNER;
        }

        public bool HasWinner()
        {
            if (GetWinnerCharacter() == NO_WINNER) return false;
            return true;
        }

        public bool HasAcceptableMove(Coordinate coordinate)
        {
            if (!CellIsAvailable(coordinate.X, coordinate.Y)) return false;
            return true;
        }

        public bool IsFull()
        {
            for(int row = 0; row < SIZE_OF_BOARD; row++)
            {
                for (int column = 0; column < SIZE_OF_BOARD; column++)
                {
                    if (_board[row, column].IsAvailable()) return false;
                }
            }
            return true;
        }


    }
}
