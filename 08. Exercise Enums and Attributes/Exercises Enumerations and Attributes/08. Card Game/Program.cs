using _08.Card_Game.Entity;
using _08.Card_Game.Enums;
using System;

namespace _08.Card_Game
{
    public class Program
    {
        public static void Main()
        {
            // Create deck
            Deck deck = new Deck();
            deck.AddCardsToDeck();

            // Create players
            Player first = new Player(Console.ReadLine());
            Player second = new Player(Console.ReadLine());

            // Read 5 cards for each player
            ReadPlayerCards(first, deck);
            ReadPlayerCards(second, deck);

            // Print winner
            Console.WriteLine(first.MostPowerfullCard.CompareTo(second.MostPowerfullCard) > 0 ? first : second);
        }

        private static void ReadPlayerCards(Player player, Deck deck)
        {
            while (player.Cards.Count != 5)
            {
                string[] cardArgs = Console.ReadLine()
                    .Split(new string[] { " of " }, StringSplitOptions.RemoveEmptyEntries);

                if (CardIsValid(cardArgs))
                {
                    Card card = new Card(cardArgs[0], cardArgs[1]);

                    if (deck.CardIsInDeck(card))
                    {
                        player.Cards.Add(card); // Add to players deck
                        deck.RemoveFromDeck(card); // Remove card from deck
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                else
                {
                    Console.WriteLine("No such card exists.");
                }
            }
        }

        private static bool CardIsValid(string[] card)
        {
            string rank = card[0];
            string suit = card[1];

            if (Enum.TryParse(rank, out Rank parsedRank) && Enum.TryParse(suit, out Suit parsedSuit))
            {
                return true;
            }

            return false;
        }
    }
}