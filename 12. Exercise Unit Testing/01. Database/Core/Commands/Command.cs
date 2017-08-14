using _01.Database.Contracts;
using _01.Database.Entities;

namespace _01.Database.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private readonly Database<int> db;
        private readonly string[] input;
        private IOutputStore output;

        protected Command(Database<int> db, string[] input, IOutputStore output)
        {
            this.db = db;
            this.input = input;
            this.output = output;
        }

        protected string[] Input => this.input;
        protected IDatabase<int> Database => this.db;
        protected IOutputStore Output => this.output;

        public abstract void Execute();
    }
}