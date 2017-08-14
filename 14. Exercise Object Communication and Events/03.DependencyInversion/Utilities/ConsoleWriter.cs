using System;
using _03.DependencyInversion.Interfaces;

namespace _03.DependencyInversion.Utilities
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string report)
        {
            if (!string.IsNullOrEmpty(report))
            {
                Console.WriteLine(report);
            }
        }
    }
}