using _06.Generic_Count_Method_Strings.Generics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Generic_Count_Method_Strings
{
    public class Program
    {
        public static void Main()
        {
            List<Box<string>> list = new List<Box<string>>(); // List to store read data

            // Read data
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                list.Add(new Box<string>(Console.ReadLine()));
            }

            // Read compare string
            string toCompareWith = Console.ReadLine();

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