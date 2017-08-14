using _01.Database.Contracts;
using _01.Database.Entities;

namespace _01.Database.Core.Commands
{
    public class Remove : Command
    {
        public Remove(Database<int> db, string[] input, IOutputStore output) : base(db, input, output)
        {
        }

        public override void Execute()
        {
            this.Database.Remove();
        }
    }
}