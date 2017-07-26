using System;

namespace SimpleJudje.Exceptions
{
    public class InvalidTakeCommand : Exception
    {
        private const string InvalidTake = "{0} is invalid take command! Use 'take'.";

        public InvalidTakeCommand(string invalidCommand)
            : base(string.Format(InvalidTake, invalidCommand))
        {
        }
    }
}