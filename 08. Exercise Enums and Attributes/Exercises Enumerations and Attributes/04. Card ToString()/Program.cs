using _04.Card_ToString__.Entity;
using System;

namespace _04.Card_ToString__
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