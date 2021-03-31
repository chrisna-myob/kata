using System.Reflection.Metadata;
using System;

namespace TicTacToe
{
    public class Game
    {
        private const char NO_WINNER = Char.MinValue;
        private const string QUIT_GAME = "q";
        

        private Board _board;
        private Player _player1;
        private Player _player2;

        private Player _currentPlayer;

        public Game()
        {
            _player1 = new Player('X', 1, true);
            _player2 = new Player('O', 2, false);
            _board = new Board();
        }

        public void Play()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine();
            _board.PrintBoard();

            var end_game = false;
            while (!end_game) 
            {
                _currentPlayer = FindActivePlayer();

                var coordinates = GetPlayerMoveCoordinates();

                if (_board.HasAcceptableMove(coordinates)) {
                    _board.MarkPlayersMove(_currentPlayer.Character, coordinates);
                } else {
                    Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                    continue;
                }

                if (IsGameEnd()) 
                {
                    end_game = true;
                }
                else {
                    Console.WriteLine("Move accepted, here's the current board:");
                    _board.PrintBoard();
                }
                SwitchUser();
            }
        }

        private void SwitchUser()
        {
            this._player1.ToggleActive();
            this._player2.ToggleActive();
        }

        private Player FindActivePlayer()
        {
            return (this._player1.IsActive) ? this._player1 : this._player2;
        }

        public Coordinate GetPlayerMoveCoordinates()
        {
            while (true)
            {
                Console.Write($"Player {_currentPlayer.Number} enter a coord x,y to place your {_currentPlayer.Character} or enter 'q' to give up: ");
                var input = Console.ReadLine();
                if (input == QUIT_GAME)
                {
                    Console.WriteLine("You have given up. :(");
                    System.Environment.Exit(0);
                }

                var coordinates = TurnInputIntoCoordinate(input);
                
                return coordinates;   
            }
        }

        private Coordinate TurnInputIntoCoordinate(string input)
        {
            int x, y;
            var stringArray = new string[2];

            try
            {
                stringArray = input.Split(",");

                if (stringArray.Length == 1) 
                {
                    throw new IndexOutOfRangeException();
                }

            }
            catch (IndexOutOfRangeException)
            {
                return new Coordinate(-1, -1);
            }
            
            var rowResult = Int32.TryParse(stringArray[0], out x);
            var columnResult = Int32.TryParse(stringArray[1], out y);
        
            return new Coordinate(x, y);

        }

        public void DisplayResults()
        {
            var winningCharacter = _board.GetWinnerCharacter();
            if (winningCharacter == NO_WINNER)
            {
                Console.WriteLine("No one has won, there's a tie!");
            } else {
                Console.WriteLine($"Move accepted, well done Player {winningCharacter} you've won the game!");
            }
            _board.PrintBoard();
        }

        private bool IsGameEnd()
        {
            if (_board.IsFull()) return true;
            else if (_board.HasWinner()) return true;
            return false;
        }
        
    }
}
