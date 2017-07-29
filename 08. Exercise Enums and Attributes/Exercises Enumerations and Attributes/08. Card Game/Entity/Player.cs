using System.Collections.Generic;
using System.Linq;

namespace _08.Card_Game.Entity
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
            this.Cards = new List<Card>();
        }

        public string Name { get; set; }
        public IList<Card> Cards { get; private set; }
        public Card MostPowerfullCard => this.Cards.OrderByDescending(c => c.GetPower()).First();

        public override string ToString() => $"{this.Name} wins with {this.MostPowerfullCard.Rank} of {this.MostPowerfullCard.Suit}.";
    }
}