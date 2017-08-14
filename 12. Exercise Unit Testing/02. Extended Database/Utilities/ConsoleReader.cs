using _02.Extended_Database.Contracts;
using System;

namespace _02.Extended_Database.Utilities
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}