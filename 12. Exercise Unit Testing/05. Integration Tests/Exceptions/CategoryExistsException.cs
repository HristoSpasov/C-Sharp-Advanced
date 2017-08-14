using System;

namespace _05.Integration_Tests.Exceptions
{
    public class CategoryExistsException : Exception
    {
        private const string message = "Category '{0}' already exists!";

        public CategoryExistsException(string name) :
            base(string.Format(message, name))
        {
        }
    }
}