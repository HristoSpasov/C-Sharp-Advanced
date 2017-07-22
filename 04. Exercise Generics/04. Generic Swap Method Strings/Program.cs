using System;
using System.Collections.Generic;
using System.Linq;
using _04.Generic_Swap_Method_Strings.Generics;

namespace _04.Generic_Swap_Method_Strings
{
    public class Program
    {
        public static void Main()
        {
            List<Box<string>> strList = new List<Box<string>>(); // List to hold data

            // Read input data
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                strList.Add(new Box<string>(Console.ReadLine()));
            }

            // Read swap indices
            int[] swapIndices = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SwapCollectionElements(strList, swapIndices); // Swap elements

            GenericPrint(strList); // Print list
        }

        private static void GenericPrint<T>(List<T> strList)
        {
            foreach (var str in strList)
            {
                Console.WriteLine(str.ToString());
            }
        }

        private static void SwapCollectionElements<T>(List<T> list, int[] swapIndices)
        {
            T tmp = list[swapIndices[0]];
            list[swapIndices[0]] = list[swapIndices[1]];
            list[swapIndices[1]] = tmp;
        }
    }
}