using System;

namespace _11.Inferno_Infinity.Utilities
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