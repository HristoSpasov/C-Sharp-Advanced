using System;
using _03.DependencyInversion.Interfaces;

namespace _03.DependencyInversion.Utilities
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}