using _01.Generic_Box.Generics;
using System;

namespace _01.Generic_Box
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int intInput))
            {
                Box<int> box = new Box<int>(intInput);
                Console.WriteLine(box.ToString());
            }
            else
            {
                Box<string> box = new Box<string>(input);
                Console.WriteLine(box.ToString());
            }
        }
    }
}