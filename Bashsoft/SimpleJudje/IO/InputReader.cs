using SimpleJudje.Contracts;
using System;

namespace SimpleJudje.IO
{
    public class InputReader : IReader
    {
        private const string endComand = "quit";
        private readonly IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            string input = Console.ReadLine();
            input = input.Trim();
            this.interpreter.InterpreteCommand(input); // Proces command input

            while (true)
            {
                // Interpret command
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                input = Console.ReadLine();
                input = input.Trim();

                this.interpreter.InterpreteCommand(input); // Proces command input

                if (input == endComand)
                {
                    // Close program
                    break;
                }
            }
        }
    }
}