using _02.Extended_Database.Contracts;
using _02.Extended_Database.Entities;

namespace _02.Extended_Database.Core.Commands
{
    public class FindByUsername : Command
    {
        public FindByUsername(Database<Person> db, string[] input, IOutputStore output) : base(db, input, output)
        {
        }

        public override void Execute()
        {
            this.Database.FindByUsername(this.Input[1]);
        }
    }
}