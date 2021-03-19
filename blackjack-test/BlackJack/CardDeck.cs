using System;
using BlackJack;
using System.Collections.Generic;

namespace BlackJack
{
    public class CardDeck
    {
        private List<Card> _deck;

        public List<Card> Deck => _deck;
        public CardDeck()
        {
            _deck = new List<Card>();
        } 

        public void MakeDeck()
        {
            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach(Value value in Enum.GetValues(typeof(Value)))
                {
                    _deck.Add(new Card(suit, value));
                }
            }

        }
        public void Shuffle()  
        {  
            Random random = new Random();  
            int n = _deck.Count;  

            for(int i= _deck.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);  

                var value = _deck[rnd];  
                _deck[rnd] = _deck[i];  
                _deck[i] = value;
            }
        }

        public Card Draw()
        {
            var removedCard = _deck[0];
            _deck.Remove(removedCard);
            return removedCard;
        }

        
    }
}