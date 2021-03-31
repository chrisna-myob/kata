using System;

namespace TicTacToe
{
    public class Player
    {
        private char _character;
        private int _number;

        private bool _isActive;
        private const string QUIT_GAME = "q";

        public char Character {
            get { return _character; }
            private set { _character = value; }
        }

        public int Number {
            get { return _number; }
            private set { _number = value; }
        }

        public bool IsActive {
            get { return _isActive; }
            private set { _isActive = value; }
        }

        public Player(char character, int number, bool isActive = false)
        {
            Character = character;
            Number = number;
            IsActive = isActive;
        }


        public void ToggleActive()
        {
            IsActive = !IsActive;
        }

    }
}
