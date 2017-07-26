using System;

namespace SimpleJudje.Exceptions
{
    public class InvalidStringException : Exception
    {
        private const string invalidStringExceptionMessage = "String cannot be empty!";

        public InvalidStringException()
            : base(invalidStringExceptionMessage)
        {
        }

        public InvalidStringException(string exception)
            : base(exception)
        {
        }
    }
}