using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;

namespace SimpleJudje.IO
{
    public class PrintOrderedStudentsCommand : Command, IExecutable
    {
        public PrintOrderedStudentsCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManagar) : base(input, data, judge, repository, inputOutputManagar)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 5)
            {
                string courseName = this.Data[1];
                string order = this.Data[2].ToLower();
                string takeCommand = this.Data[3].ToLower();
                string takeQuantity = this.Data[4].ToLower();

                this.TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, order);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string order)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.Repository.OrderAndTake(courseName, order);
                }
                else
                {
                    int studentsToTake = 0;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);

                    if (hasParsed)
                    {
                        this.Repository.OrderAndTake(courseName, order, studentsToTake);
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