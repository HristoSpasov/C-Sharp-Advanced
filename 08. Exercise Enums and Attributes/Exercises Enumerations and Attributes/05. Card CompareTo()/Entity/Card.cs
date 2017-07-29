using _05.Card_CompareTo__.Enums;
using System;

namespace _05.Card_CompareTo__.Entity
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

        public override string ToString() => $"Card name: {this.Rank} of {this.Suit}; Card power: {this.GetPower()}";

        private int GetPower()
        {
            CardRanks rank = (CardRanks)Enum.Parse(typeof(CardRanks), this.Rank);
            CardSuits suit = (CardSuits)Enum.Parse(typeof(CardSuits), this.Suit);

            return (int)rank + (int)suit;
        }
    }
}