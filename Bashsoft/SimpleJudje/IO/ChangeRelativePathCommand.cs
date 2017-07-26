using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;

namespace SimpleJudje.IO
{
    public class ChangeRelativePathCommand : Command, IExecutable
    {
        public ChangeRelativePathCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManagar) : base(input, data, judge, repository, inputOutputManagar)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string relPath = this.Data[1];
                this.InputOutputManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}