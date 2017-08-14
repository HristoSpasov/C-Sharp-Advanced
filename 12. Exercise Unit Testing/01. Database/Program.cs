using _01.Database.Contracts;
using _01.Database.Core;
using _01.Database.Entities;
using _01.Database.Utilities;
using System;

namespace _01.Database
{
    public class Program
    {
        private const int DefaultSize = 16;

        public static void Main()
        {
            // Generate array
            EmptyArrayGenerator<int> arrayGenerator = new EmptyArrayGenerator<int>();
            int[] array = arrayGenerator.CreateArray(DefaultSize);

            // Generate database
            Database<int> db = new Database<int>(array);

            // Reader
            IReader reader = new ConsoleReader();
            IOutputStore output = new OutputStore();

            // Run program
            Engine engine = new Engine(reader, output, db);
            engine.Run();

            // Print report
            Console.WriteLine(output.GetOutput());
        }
    }
}