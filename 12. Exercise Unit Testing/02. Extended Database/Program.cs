using _02.Extended_Database.Contracts;
using _02.Extended_Database.Core;
using _02.Extended_Database.Entities;
using _02.Extended_Database.Utilities;
using System;

namespace _02.Extended_Database
{
    public class Program
    {
        private const int DefaultSize = 16;

        public static void Main()
        {
            // Generate array
            EmptyArrayGenerator<Person> arrayGenerator = new EmptyArrayGenerator<Person>();
            Person[] array = arrayGenerator.CreateArray(DefaultSize);

            // Generate database
            Database<Person> db = new Database<Person>(array);

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