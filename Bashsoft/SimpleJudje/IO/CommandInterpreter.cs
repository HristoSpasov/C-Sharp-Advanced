using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;
using System;

namespace SimpleJudje.IO
{
    public class CommandInterpreter : IInterpreter
    {
        private readonly IContentComparer judge;
        private readonly IDatabase repository;
        private readonly IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpreteCommand(string input)
        {
            string[] data = input.Split();
            string commandName = data[0];

            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private Command ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "ls":
                    return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "cmp":
                    return new CompareFilesCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "cdrel":
                    return new ChangeRelativePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "cdabs":
                    return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "readdb":
                    return new ReadDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "show":
                    return new ShowCourseCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "dropdb":
                    return new DropDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                default:
                    throw new InvalidCommandException(input);
            }
        }
    }
}