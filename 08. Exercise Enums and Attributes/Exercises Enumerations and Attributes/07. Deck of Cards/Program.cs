using _07.Deck_of_Cards.Enums;
using System;

namespace _07.Deck_of_Cards
{
    public class Program
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            string[] suits = typeof(Suit).GetEnumNames();
            string[] ranks = typeof(Rank).GetEnumNames();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    Console.WriteLine($"{rank} of {suit}");
                }
            }
        }
    }
}