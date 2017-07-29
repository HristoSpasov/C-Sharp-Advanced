using _02.Card_Rank.Enums;
using System;

namespace _02.Card_Rank
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string[] cards = typeof(CardRanks).GetEnumNames();

            Console.WriteLine("Card Ranks:");

            foreach (var card in cards)
            {
                CardRanks parsed = (CardRanks)Enum.Parse(typeof(CardRanks), card);

                Console.WriteLine($"Ordinal value: {(int)parsed}; Name value: {parsed}");
            }
        }
    }
}