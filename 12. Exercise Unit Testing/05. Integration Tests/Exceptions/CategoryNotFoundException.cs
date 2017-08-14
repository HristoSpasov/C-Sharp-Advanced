using System;

namespace _05.Integration_Tests.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        private const string message = "Category with '{0}' does not exist in database!";

        public CategoryNotFoundException(string name)
            : base(string.Format(message, name))
        {
        }
    }
}