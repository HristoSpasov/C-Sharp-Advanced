using System;

namespace _12.Threeuple
{
    public class Program
    {
        public static void Main()
        {
            // First tuple
            string[] first = Console.ReadLine().Split();
            Threeuple<string, string, string> tuple1 = new Threeuple<string, string, string>(first[0] + " " + first[1], first[2], first[3]);

            // Second tuple
            string[] second = Console.ReadLine().Split();
            Threeuple<string, int, bool> tuple2 = new Threeuple<string, int, bool>(second[0], int.Parse(second[1]), (second[2] == "drunk"));

            // Third tuple
            string[] third = Console.ReadLine().Split();
            Threeuple<string, double, string> tuple3 = new Threeuple<string, double, string>(third[0], double.Parse(third[1]), third[2]);

            // Print tuples
            Console.WriteLine(tuple1.ToString());
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
