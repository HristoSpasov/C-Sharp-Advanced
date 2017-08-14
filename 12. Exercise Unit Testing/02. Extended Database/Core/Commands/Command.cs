using _02.Extended_Database.Contracts;
using _02.Extended_Database.Entities;

namespace _02.Extended_Database.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private readonly Database<Person> db;
        private readonly string[] input;
        private IOutputStore output;

        protected Command(Database<Person> db, string[] input, IOutputStore output)
        {
            this.db = db;
            this.input = input;
            this.output = output;
        }

        protected string[] Input => this.input;
        protected IDatabase<Person> Database => this.db;
        protected IOutputStore Output => this.output;

        public abstract void Execute();
    }
}