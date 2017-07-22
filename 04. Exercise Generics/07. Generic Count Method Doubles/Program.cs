using _07.Generic_Count_Method_Doubles.Generics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Generic_Count_Method_Doubles
{
    public class Program
    {
        public static void Main()
        {
            List<Box<double>> list = new List<Box<double>>(); // List to store read data

            // Read data
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                list.Add(new Box<double>(double.Parse(Console.ReadLine())));
            }

            // Read compare string
            double toCompareWith = double.Parse(Console.ReadLine());

            // Call generic method to calculate strings larger tha
            int greaterThanCompareWithCount = GetGreaterElements(list, toCompareWith);

            // Print result
            Console.WriteLine(greaterThanCompareWithCount);
        }

        private static int GetGreaterElements<T>(List<Box<T>> list, T toCompareWith)
            where T : IComparable<T>
        {
            return list.Where(s => s.Value.CompareTo(toCompareWith) == 1).Select(s => s).Count();
        }
    }
}