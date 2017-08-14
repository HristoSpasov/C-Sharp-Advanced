using _01.Database.Contracts;
using System;

namespace _01.Database.Utilities
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}