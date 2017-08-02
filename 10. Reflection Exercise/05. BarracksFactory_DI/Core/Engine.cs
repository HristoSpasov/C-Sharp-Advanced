using _05.BarracksFactory_DI.Core.Factories;

namespace _05.BarracksFactory_DI.Core
{
    using Contracts;
    using System;

    internal class Engine : IRunnable
    {
        private readonly IRepository repository;
        private readonly IUnitFactory unitFactory;
        private readonly ICommandFactory commandFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
            this.commandFactory = new CommandFactory();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (input == "fight")
                    {
                        break;
                    }

                    string[] data = input.Split();
                    IExecutable command = this.commandFactory.CreateCommand(data, this.repository, this.unitFactory);
                    string result = command.Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}