using System;

namespace SimpleJudje.Exceptions
{
    public class InvalidPathException : Exception
    {
        private const string InvalidPath = "The sourse does not exist.";

        public InvalidPathException()
            : base(InvalidPath)
        {
        }

        public InvalidPathException(string message)
            : base()
        {
        }
    }
}