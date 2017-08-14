using _02.Extended_Database.Contracts;
using _02.Extended_Database.Entities;

namespace _02.Extended_Database.Core.Commands
{
    public class FindById : Command
    {
        public FindById(Database<Person> db, string[] input, IOutputStore output) : base(db, input, output)
        {
        }

        public override void Execute()
        {
            this.Database.FindById(long.Parse(this.Input[1]));
        }
    }
}