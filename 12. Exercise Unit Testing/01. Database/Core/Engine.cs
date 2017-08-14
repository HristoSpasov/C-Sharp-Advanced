using _01.Database.Contracts;
using _01.Database.Entities;
using _01.Database.Factories;

namespace _01.Database.Core
{
    public class Engine
    {
        private IReader reader;
        private IOutputStore output;
        private Database<int> db;
        private CommandFactory cmdFactory;

        public Engine(IReader reader, IOutputStore output, Database<int> db)
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

                IExecutable cmd = this.cmdFactory.GetCommand(this.db, line, this.output);
                cmd.Execute();
            }
        }
    }
}