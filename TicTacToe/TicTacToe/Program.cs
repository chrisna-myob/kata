using System.Reflection.Metadata;
using System;
using TicTacToe;

namespace TicTacToe
{
    class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.Play();
            game.DisplayResults();
        }
    }
}
