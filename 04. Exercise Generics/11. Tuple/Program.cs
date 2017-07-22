using System;

namespace _11.Tuple
{
    public class Program
    {
        public static void Main()
        {
            // Read person tuple
            string[] first = Console.ReadLine().Split();
            Tuple<string, string> tuple1 = new Tuple<string, string>(first[0] + " " + first[1], first[2]);

            // Name and amount of beer
            string[] second = Console.ReadLine().Split();
            Tuple<string, int> tuple2 = new Tuple<string, int>(second[0], int.Parse(second[1]));

            // Integer and double
            string[] third = Console.ReadLine().Split();
            Tuple<int, double> tuple3 = new Tuple<int, double>(int.Parse(third[0]), double.Parse(third[1]));

            // Print tupels
            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}