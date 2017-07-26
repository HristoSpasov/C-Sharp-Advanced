using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;

namespace SimpleJudje.IO
{
    public class CompareFilesCommand : Command, IExecutable
    {
        public CompareFilesCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManagar) : base(input, data, judge, repository, inputOutputManagar)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 3)
            {
                string firstPath = this.Data[1];
                string secondPath = this.Data[2];

                this.Judge.CompareContent(firstPath, secondPath);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}