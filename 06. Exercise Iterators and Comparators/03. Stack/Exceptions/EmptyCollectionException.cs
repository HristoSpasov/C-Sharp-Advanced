using System;

namespace _03.Stack.Exceptions
{
    public class EmptyCollectionException : Exception
    {
        private const string message = "No elements";

        public EmptyCollectionException()
            : base(message)
        {
        }
    }
}