using _02.Extended_Database.Contracts;
using _02.Extended_Database.Entities;

namespace _02.Extended_Database.Core.Commands
{
    public class Add : Command
    {
        public Add(Database<Person> db, string[] input, IOutputStore output) : base(db, input, output)
        {
        }

        public override void Execute()
        {
            long id = long.Parse(this.Input[1]);
            string userName = this.Input[2];
            this.Database.Add(new Person(id, userName));
        }
    }
}