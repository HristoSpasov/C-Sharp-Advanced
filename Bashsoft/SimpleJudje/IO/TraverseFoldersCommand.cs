namespace SimpleJudje.IO
{
    using SimpleJudje.Attributes;
    using SimpleJudje.Contracts;
    using SimpleJudje.Exceptions;

    [Alias("ls")]
    public class TraverseFoldersCommand : Command, IExecutable
    {
        [Inject]
        private readonly IDirectoryManager inputOutputManager;

        public TraverseFoldersCommand(string input, string[] data) : base(input, data)
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
                this.inputOutputManager.TraverseDirectory(0); // No params so travrse curr dir
            }
            else if (this.Data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(this.Data[1], out depth);
                if (hasParsed)
                {
                    this.inputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    throw new InvalidTraverseDepth(this.Data[1]);
                }
            }
        }
    }
}