using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;
using System.Diagnostics;

namespace SimpleJudje.IO
{
    public class OpenFileCommand : Command, IExecutable
    {
        public OpenFileCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileName = this.Data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }
}