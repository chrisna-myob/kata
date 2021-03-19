using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player : IPlayer
    {
        private const int BLACK_JACK = 21;
        private List<Card> _hand;
        private int _score;

        public int Score => _score;

        public Player()
        {
            _hand = new List<Card>();
            _score = 0;
        }

        public void AddToHand(Card card)
        {
            _hand.Add(card);
            if (card.Value == Value.Ace && this.Score + (int)card.Value > 21) {
                _score += 1;
            } else {
                _score += (int)card.Value;
            }
        }

        public string HandToString()
        {
            if (_hand.Count == 1)
            {
                return _hand[0].ToString();
            }

            var str = "";
            for(int card = 0; card < _hand.Count; card++)
            {
                if (card + 1 == _hand.Count)
                {
                    str += _hand[card];
                } else {
                    str += $"{_hand[card]}, ";
                }
                
            }

            return $"[{str}]";

        }

        public bool IsBust()
        {
            return _score > BLACK_JACK ? true : false;
        }

        public bool HasBlackJack()
        {
            return _score == BLACK_JACK ? true : false;
        }

        static void ProcessInput(bool result, int number)
        {
            
        }

        public int Move()
        {
            int number;
            var input = Console.ReadLine();
            var result = Int32.TryParse(input, out number);
            try
            {
                if (!result)
                {
                    throw new ArgumentException();
                }
                if (!(number == 0 || number == 1)) {
                    throw new ArgumentException();
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine($"{e} Can only choose between 1 or 0.");
                System.Environment.Exit(0);  
            }
            
            return number;

        }


    }
}