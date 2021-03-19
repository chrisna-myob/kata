using System;
using BlackJack;
using System.Collections.Generic;

namespace BlackJack
{
    public class Game
    {
        public const int BLACK_JACK = 21;
        public const int SCORE_DEALER_CANNOT_EXCEED = 17;
        private Player _player;
        private Player _dealer;

        private CardDeck _deck;

        public void SetUp()
        {
            _deck = new CardDeck();
            _deck.MakeDeck();
            _deck.Shuffle();
            _player = new Player();
            _dealer = new Player();

            _player.AddToHand(_deck.Draw());
            _player.AddToHand(_deck.Draw());

            _dealer.AddToHand(_deck.Draw());
            _dealer.AddToHand(_deck.Draw());
        }
        public void Play()
        {
            var stay = false;
            do {
                DisplayCurrentScoreAndHand(_player, "You are at currently at", "with the hand");
                Console.Write("Hit or stay? (Hit = 1, Stay = 0)");

                int choice = _player.Move();
                
                if (choice == 1)
                {
                    AddCardToPlayerHand(_player, "You draw");
                } else {
                    stay = true;
                }

                Console.WriteLine();

                if (_player.IsBust())
                {
                    stay = true;
                }
            } while (!stay);

            if (!_player.IsBust()) {
                while (_dealer.Score < SCORE_DEALER_CANNOT_EXCEED) {
                    DisplayCurrentScoreAndHand(_dealer, "Dealer is at", "with the hand");
                    AddCardToPlayerHand(_dealer, "Dealer draws");
                    Console.WriteLine();
                }
            } 

            return;
            
        }

        public void DisplayCurrentScoreAndHand(Player player, string scoreMessage, string handMessage)
        {
            Console.WriteLine($"{scoreMessage} {player.Score}");
            Console.WriteLine($"{handMessage} {player.HandToString()}");
            Console.WriteLine();
        }


        public void AddCardToPlayerHand(Player player, string message)
        {
            var drawnCard = _deck.Draw();
            player.AddToHand(drawnCard);
            Console.WriteLine($"{message} {drawnCard.ToString()}");
        }

        public void DisplayWinner()
        {
            if (_dealer.IsBust() && _player.IsBust() || _dealer.HasBlackJack() && _player.HasBlackJack()) {
                Console.WriteLine("You tied with the dealer, nobody wins.");
                return;
            }

            if (_player.IsBust()) 
            {
                Console.WriteLine($"You are at currently at Bust!");
                Console.WriteLine($"with the hand {_player.HandToString()}");
                Console.WriteLine();
                Console.WriteLine("Dealer wins!");
                return;
            }
            
            if (_player.HasBlackJack() || !_player.IsBust() && _dealer.IsBust() || Math.Abs(_player.Score - BLACK_JACK) < Math.Abs(_dealer.Score - BLACK_JACK)) {
                Console.WriteLine("You beat the dealer!");
            } else {
                Console.WriteLine("Dealer wins!");
            }
        }
    }
}