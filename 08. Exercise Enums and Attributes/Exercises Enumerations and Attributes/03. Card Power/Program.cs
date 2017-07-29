using _03.Card_Power.Entity;
using System;

namespace _03.Card_Power
{
    public class Program
    {
        public static void Main()
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();

            Console.WriteLine(new Card(rank, suit));
        }
    }
}