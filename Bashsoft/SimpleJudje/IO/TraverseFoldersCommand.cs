using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;

namespace SimpleJudje.IO
{
    public class TraverseFoldersCommand : Command, IExecutable
    {
        public TraverseFoldersCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManagar) : base(input, data, judge, repository, inputOutputManagar)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1 && this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            if (this.Data.Length == 1)
            {
                this.InputOutputManager.TraverseDirectory(0); // No params so travrse curr dir
            }
            else if (this.Data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(this.Data[1], out depth);
                if (hasParsed)
                {
                    this.InputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    throw new InvalidTraverseDepth(this.Data[1]);
                }
            }
        }
    }
}