using System;

namespace _03.Iterator_Test.Exceptions
{
    public class EmptyCollectionException : Exception
    {
        private const string message = "Invalid Operation!";

        public EmptyCollectionException()
            : base(message)
        {
        }
    }
}