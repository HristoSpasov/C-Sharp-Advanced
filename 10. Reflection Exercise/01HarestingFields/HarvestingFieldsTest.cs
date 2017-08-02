using _01HarestingFields.Commands;
using _01HarestingFields.Factories;
using _01HarestingFields.Utilities;

namespace _01HarestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Run(); // Run code
            Console.WriteLine(OutputGeneratorAndPrinter.GetReport()); // Print result
        }

        private static void Run()
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "HARVEST")
                {
                    break;
                }

                Command command = CommandFactory.GetCommand(line);
                command.Execute();
            }
        }
    }
}