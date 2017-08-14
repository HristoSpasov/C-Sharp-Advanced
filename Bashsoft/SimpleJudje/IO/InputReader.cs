namespace SimpleJudje.IO
{
    using System;
    using SimpleJudje.Contracts;

    public class InputReader : IReader
    {
        private const string EndComand = "quit";
        private readonly IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
            string input = Console.ReadLine();
            input = input.Trim();
            this.interpreter.InterpreteCommand(input); // Proces command input

            while (true)
            {
                // Interpret command
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
                input = Console.ReadLine();
                input = input.Trim();

                this.interpreter.InterpreteCommand(input); // Proces command input

                if (input == EndComand)
                {
                    // Close program
                    break;
                }
            }
        }
    }
}