using System;
using _02.Generic_Box_of_String.Generics;

namespace _02.Generic_Box_of_String
{
    public class Program
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                Box<string> currBox = new Box<string>(Console.ReadLine());
                Console.WriteLine(currBox.ToString());
            }
        }
    }
}