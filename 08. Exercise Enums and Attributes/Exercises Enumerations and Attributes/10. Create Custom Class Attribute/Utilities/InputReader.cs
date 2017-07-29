using System;

namespace _10.Create_Custom_Class_Attribute.Utilities
{
    public static class InputReader
    {
        public static string[] ReadLine()
        {
            var readLine = Console.ReadLine();
            return readLine?.Split(';');
        }
    }
}