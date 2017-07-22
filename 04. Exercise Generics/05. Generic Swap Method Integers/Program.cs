using System;
using System.Collections.Generic;
using System.Linq;
using _05.Generic_Swap_Method_Integers.Generics;

namespace _05.Generic_Swap_Method_Integers
{
    public class Program
    {
        public static void Main()
        {
            List<Box<int>> strList = new List<Box<int>>(); // List to hold data

            // Read input data
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                strList.Add(new Box<int>(int.Parse(Console.ReadLine())));
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