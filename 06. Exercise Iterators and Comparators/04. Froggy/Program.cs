using _04.Froggy.Entities;
using System;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    public class Program
    {
        public static void Main()
        {
            // Read stones
            Lake lake = new Lake(Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            // Get result
            StringBuilder result = new StringBuilder();

            foreach (var stone in lake)
            {
                result.Append(stone).Append(", ");
            }

            // Print result
            Console.WriteLine(result.ToString().TrimEnd(", ".ToCharArray()));
        }
    }
}