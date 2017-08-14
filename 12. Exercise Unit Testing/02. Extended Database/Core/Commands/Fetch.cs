using _02.Extended_Database.Contracts;
using _02.Extended_Database.Entities;

namespace _02.Extended_Database.Core.Commands
{
    public class Fetch : Command
    {
        public Fetch(Database<Person> db, string[] input, IOutputStore output) : base(db, input, output)
        {
        }

        public override void Execute()
        {
            this.Database.Fetch();
        }
    }
}