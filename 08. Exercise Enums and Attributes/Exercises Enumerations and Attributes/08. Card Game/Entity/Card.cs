using _08.Card_Game.Enums;
using System;

namespace _08.Card_Game.Entity
{
    public class Card : IComparable<Card>
    {
        public Card(string rank, string suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public string Rank { get; set; }
        public string Suit { get; set; }

        public int CompareTo(Card other) => this.GetPower() - other.GetPower();

        public int GetPower()
        {
            Rank rank = (Rank)Enum.Parse(typeof(Rank), this.Rank);
            Suit suit = (Suit)Enum.Parse(typeof(Suit), this.Suit);

            return (int)rank + (int)suit;
        }
    }
}