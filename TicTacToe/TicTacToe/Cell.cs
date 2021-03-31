using System;

namespace TicTacToe
{
    public class Cell
    {
        private char _value;

        public char Value 
        {
            get { return _value; }
            set { _value = value; }
        }

        public Cell(char value)
        {
            Value = value;
        }

        public bool IsAvailable()
        {
            return _value == '.' ? true : false;
        }

}
}
