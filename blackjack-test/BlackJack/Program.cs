using System;
using BlackJack;
using System.Collections.Generic;

namespace BlackJack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.SetUp();
            game.Play();
            game.DisplayWinner();
        }

        
    }
}