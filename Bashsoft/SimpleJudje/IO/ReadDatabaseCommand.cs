using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;

namespace SimpleJudje.IO
{
    public class ReadDatabaseCommand : Command, IExecutable
    {
        public ReadDatabaseCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManagar) : base(input, data, judge, repository, inputOutputManagar)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileName = this.Data[1];
            this.Repository.LoadData(fileName);
        }
    }
}