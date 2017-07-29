using _01.Card_Suit.Enums;
using System;

namespace _01.Card_Suit
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string[] cards = typeof(CardSuits).GetEnumNames();

            Console.WriteLine("Card Suits:");

            foreach (var card in cards)
            {
                CardSuits suitId = (CardSuits)Enum.Parse(typeof(CardSuits), card);
                Console.WriteLine($"Ordinal value: {(int)suitId}; Name value: {card}");
            }
        }
    }
}