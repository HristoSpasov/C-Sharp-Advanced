using System;

namespace _05.Integration_Tests.Exceptions
{
    public class CategoryNullException : Exception
    {
        private const string message = "Category cannot be null.";

        public CategoryNullException() : base(message)
        {
        }
    }
}