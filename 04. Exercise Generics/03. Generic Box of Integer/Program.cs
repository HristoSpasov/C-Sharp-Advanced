using System;
using _03.Generic_Box_of_Integer.Generics;

namespace _03.Generic_Box_of_Integer
{
    public class Program
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine(new Box<int>(int.Parse(Console.ReadLine())));
            }
        }
    }
}