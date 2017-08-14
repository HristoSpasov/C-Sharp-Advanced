namespace SimpleJudje.IO
{
    using System;
    using System.Linq;
    using System.Reflection;
    using SimpleJudje.Attributes;
    using SimpleJudje.Contracts;

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

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            object[] parametersForConstruction = new object[]
            {
                input, data
            };

            Type typeOfCommand =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .First(type => type.GetCustomAttributes(typeof(AliasAttribute))
                                       .Where(atr => atr.Equals(command))
                                       .ToArray().Length > 0);

            Type typeOfInterpreter = typeof(CommandInterpreter);

            Command cmd = (Command)Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            FieldInfo[] fieldsOfCommand = typeOfCommand.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo[] fieldsOfInterpreter = typeOfInterpreter.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute atr = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));

                if (atr != null)
                {
                    if (fieldsOfInterpreter.Any(ft => ft.FieldType == fieldOfCommand.FieldType))
                    {
                        fieldOfCommand.SetValue(cmd, fieldsOfInterpreter.First(ft => ft.FieldType == fieldOfCommand.FieldType).GetValue(this));
                    }
                }
            }

            return cmd;
        }
    }
}