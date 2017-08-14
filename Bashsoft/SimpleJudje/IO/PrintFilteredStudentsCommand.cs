namespace SimpleJudje.IO
{
    using SimpleJudje.Attributes;
    using SimpleJudje.Contracts;
    using SimpleJudje.Exceptions;

    [Alias("filter")]
    public class PrintFilteredStudentsCommand : Command, IExecutable
    {
        [Inject]
        private readonly IDatabase repository;

        public PrintFilteredStudentsCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 5)
            {
                string courseName = this.Data[1];
                string filter = this.Data[2].ToLower();
                string takeCommand = this.Data[3].ToLower();
                string takeQuantity = this.Data[4].ToLower();

                this.TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.repository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake = 0;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);

                    if (hasParsed)
                    {
                        this.repository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        throw new InvalidTakeQuantityParameter(takeQuantity);
                    }
                }
            }
            else
            {
                throw new InvalidTakeCommand(takeCommand);
            }
        }
    }
}