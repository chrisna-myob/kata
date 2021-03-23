using System;

namespace TicTacToe
{
    public class Player
    {
        private char _character;
        private int _number;

        public char Character {
            get { return _character; }
            private set { _character = value; }
        }

        public int Number {
            get { return _number; }
            private set { _number = value; }
        }

        public Player(char character, int number)
        {
            Character = character;
            Number = number;
        }
    }
}
