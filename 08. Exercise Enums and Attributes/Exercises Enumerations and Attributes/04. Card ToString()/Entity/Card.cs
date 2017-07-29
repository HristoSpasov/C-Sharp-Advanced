using _04.Card_ToString__.Enums;
using System;

namespace _04.Card_ToString__.Entity
{
    public class Card
    {
        public Card(string rank, string suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public string Rank { get; set; }
        public string Suit { get; set; }

        public override string ToString() => $"Card name: {this.Rank} of {this.Suit}; Card power: {this.GetPower()}";

        private int GetPower()
        {
            CardRanks rank = (CardRanks)Enum.Parse(typeof(CardRanks), this.Rank);
            CardSuits suit = (CardSuits)Enum.Parse(typeof(CardSuits), this.Suit);

            return (int)rank + (int)suit;
        }
    }
}