using System;

namespace TicTacToe
{
    public class Game
    {
        private Board _board;
        private Player _player1;
        private Player _player2;

        private Player _currentPlayer;

        private int _playerTurn = 1;
        public void Play()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine();
            _board.PrintBoard();

            while (_playerTurn < 9) 
            {
                _currentPlayer = GetPlayer();

                GetPlayersMove(_currentPlayer);
                if (_board.HasWon())
                {
                    break;
                } else 
                {
                    Console.WriteLine("Move accepted, here's the current board:");
                }
                _board.PrintBoard();

                _playerTurn++;
            }
        }

        private Player GetPlayer()
        {
            return (_playerTurn%2 == 0) ? _player2 : _player1;
        }

        public void SetUp()
        {
            _player1 = new Player('X', 1);
            _player2 = new Player('O', 2);
            _board = new Board();
        }

        private void GetPlayersMove(Player player)
        {
            while (true)
            {
                Console.Write($"Player {player.Number} enter a coord x,y to place your {player.Character} or enter 'q' to give up: ");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    Console.Write("You have given up. :(");
                    System.Environment.Exit(0);
                }
                var coordinateArray = input.Split(",");
                int row, column;
                var rowResult = Int32.TryParse(coordinateArray[0], out row);
                var columnResult = Int32.TryParse(coordinateArray[1], out column);

                if (!rowResult || !columnResult || !_board.IsAvailable(row, column))
                {
                    Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                } 
                else 
                {
                    _board.AddCharacterToBoard(player.Character, row, column);
                    break;
                }
            }
        }

        public void DisplayWinner()
        {
            if (_board.HasWon())
            {
                Console.WriteLine("Move accepted, well done you've won the game!");
            } else {
                Console.WriteLine("No one has won, there's a tie!");
            }

            _board.PrintBoard();
        }
        
    }
}
