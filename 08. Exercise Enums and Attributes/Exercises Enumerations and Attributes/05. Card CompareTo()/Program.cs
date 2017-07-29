using _05.Card_CompareTo__.Entity;
using System;

namespace _05.Card_CompareTo__
{
    public class Program
    {
        public static void Main()
        {
            Card first = new Card(Console.ReadLine(), Console.ReadLine());
            Card second = new Card(Console.ReadLine(), Console.ReadLine());

            Console.WriteLine(first.CompareTo(second) > 0 ? first : second);
        }
    }
}