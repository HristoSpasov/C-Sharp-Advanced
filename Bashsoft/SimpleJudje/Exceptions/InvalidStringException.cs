namespace SimpleJudje.Exceptions
{
    using System;

    public class InvalidStringException : Exception
    {
        private const string InvalidStringExceptionMessage = "String cannot be empty!";

        public InvalidStringException()
            : base(InvalidStringExceptionMessage)
        {
        }

        public InvalidStringException(string exception)
            : base(exception)
        {
        }
    }
}