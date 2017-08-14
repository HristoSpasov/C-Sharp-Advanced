using _02.Extended_Database.Contracts;
using _02.Extended_Database.Entities;
using _02.Extended_Database.Factories;
using System;

namespace _02.Extended_Database.Core
{
    public class Engine
    {
        private readonly IReader reader;
        private readonly IOutputStore output;
        private readonly Database<Person> db;
        private readonly CommandFactory cmdFactory;

        public Engine(IReader reader, IOutputStore output, Database<Person> db)
        {
            this.reader = reader;
            this.output = output;
            this.db = db;
            this.cmdFactory = new CommandFactory();
        }

        public void Run()
        {
            while (true)
            {
                string line = this.reader.ReadLine();

                if (line == "END")
                {
                    break;
                }

                try
                {
                    IExecutable cmd = this.cmdFactory.GetCommand(this.db, line, this.output);
                    cmd.Execute();
                }
                catch (Exception e)
                {
                    this.output.AddInfo(e.Message);
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}