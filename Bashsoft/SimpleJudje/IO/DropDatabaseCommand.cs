namespace SimpleJudje.IO
{
    using SimpleJudje.Attributes;
    using SimpleJudje.Contracts;
    using SimpleJudje.Exceptions;

    [Alias("dropdb")]
    public class DropDatabaseCommand : Command, IExecutable
    {
        [Inject]
        private readonly IDatabase repository;

        public DropDatabaseCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}