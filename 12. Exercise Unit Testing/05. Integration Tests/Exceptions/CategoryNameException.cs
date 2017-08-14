using System;

namespace _05.Integration_Tests.Exceptions
{
    public class CategoryNameException : Exception
    {
        private const string message = "Category name cannot be null or empty string!";

        public CategoryNameException() : base(message)
        {
        }
    }
}