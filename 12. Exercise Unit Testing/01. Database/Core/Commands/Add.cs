using _01.Database.Contracts;
using _01.Database.Entities;

namespace _01.Database.Core.Commands
{
    public class Add : Command
    {
        public Add(Database<int> db, string[] input, IOutputStore output) : base(db, input, output)
        {
        }

        public override void Execute()
        {
            this.Database.Add(int.Parse(this.Input[1]));
        }
    }
}