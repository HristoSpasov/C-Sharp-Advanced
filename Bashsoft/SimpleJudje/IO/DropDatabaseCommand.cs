using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;

namespace SimpleJudje.IO
{
    public class DropDatabaseCommand : Command, IExecutable
    {
        public DropDatabaseCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManagar) : base(input, data, judge, repository, inputOutputManagar)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.Repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}