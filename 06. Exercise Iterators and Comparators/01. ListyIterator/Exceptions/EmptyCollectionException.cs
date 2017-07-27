using System;

namespace _02.Collection.Exceptions
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