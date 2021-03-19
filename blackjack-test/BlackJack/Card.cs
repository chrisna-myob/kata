using System.Collections;
using System;

namespace BlackJack
{
    public enum Suit
    {
        Heart,
        Spade,
        Diamond,
        Club
    }

    public enum Value
    {
        Ace=11,
        Two=2,
        Three=3,
        Four=4,
        Five=5,
        Six=6,
        Seven=7,
        Eight=8,
        Nine=9,
        Ten=10,
        Jack=10,
        Queen=10,
        King=10
    }

    public class Card
    {
        public Suit Suit { get; }

        public Value Value { get; }

        public Card(Suit suit, Value value) 
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            if (this.Value == Value.Ace || this.Value == Value.Jack || this.Value == Value.Queen || this.Value == Value.King) {
                return $"['{Value.ToString().ToUpper()}', '{Suit.ToString().ToUpper()}']"; 
            } else {
                return $"[{((int)Value)}, '{Suit.ToString().ToUpper()}']";
            }
        }

        

    }
}