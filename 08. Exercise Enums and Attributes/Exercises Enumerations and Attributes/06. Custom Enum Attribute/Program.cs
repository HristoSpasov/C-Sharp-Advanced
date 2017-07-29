using _06.Custom_Enum_Attribute.Enums;
using System;
using System.Linq;
using System.Reflection;

namespace _06.Custom_Enum_Attribute
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            PrintAttributes(input == "Rank" ? typeof(Rank) : typeof(Suit));
        }

        private static void PrintAttributes(Type type)
        {
            var attr = type.GetCustomAttributes();
            Console.WriteLine(attr.ToArray()[0]);
        }
    }
}