using System;
using TicTacToe;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
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

        public void AddCharacterToBoard(char character, int x, int y)
        {
            _board[x, y].Value = character;
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

        public bool IsAvailable(int x, int y)
        {
            if(x >= SIZE_OF_BOARD || y >= SIZE_OF_BOARD) return false;
            else if(x < 0 || y < 0) return false;
            return _board[x, y].IsAvailable();
        }

        private bool HorizontalWin()
        {
            for(int row = 0; row < SIZE_OF_BOARD; row++)
            {
                if (CellEqual(_board[row, 0].Value, _board[row, 1].Value, _board[row, 2].Value)) return true;
            }
            return false;
        }

        private bool VerticalWin()
        {
            for(int column = 0; column < SIZE_OF_BOARD; column++)
            {
                if (CellEqual(_board[0, column].Value, _board[1, column].Value, _board[2, column].Value)) return true;
            }
            return false;
        }

        private bool DiagonalWin()
        {
            if (CellEqual(_board[0, 0].Value, _board[1, 1].Value, _board[2, 2].Value)) return true;
            if (CellEqual(_board[0, 2].Value, _board[1, 1].Value, _board[2, 0].Value)) return true;
            return false;
        }

        private bool CellEqual(char cell1, char cell2, char cell3)
        {
            return (cell1 != '.' && cell1 == cell2 && cell2 == cell3);
        }


        public bool HasWon()
        {
            if (HorizontalWin() || VerticalWin() || DiagonalWin()) return true;
            else return false;
        }

    }
}
