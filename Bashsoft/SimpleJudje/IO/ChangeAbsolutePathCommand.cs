using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;

namespace SimpleJudje.IO
{
    public class ChangeAbsolutePathCommand : Command, IExecutable
    {
        public ChangeAbsolutePathCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManagar) : base(input, data, judge, repository, inputOutputManagar)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string absolutePath = this.Data[1];
                this.InputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}