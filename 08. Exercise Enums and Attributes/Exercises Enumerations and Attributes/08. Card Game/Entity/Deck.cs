using _08.Card_Game.Enums;
using System.Collections.Generic;
using System.Linq;

namespace _08.Card_Game.Entity
{
    public class Deck
    {
        public Deck()
        {
            this.Cards = new List<Card>();
        }

        public IList<Card> Cards { get; set; }

        public void AddCardsToDeck()
        {
            string[] suits = typeof(Suit).GetEnumNames();
            string[] ranks = typeof(Rank).GetEnumNames();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    this.Cards.Add(new Card(rank, suit));
                }
            }
        }

        public bool CardIsInDeck(Card card) => this.Cards.Any(cp => cp.GetPower() == card.GetPower());

        public void RemoveFromDeck(Card card)
        {
            Card cardToRemove = this.Cards.First(c => c.GetPower() == card.GetPower());
            this.Cards.Remove(cardToRemove);
        }
    }
}