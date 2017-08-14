using System;

namespace _05.Integration_Tests.Exceptions
{
    public class CategoryUsersNullException : Exception
    {
        private const string message = "Category user collection cannot be null.";

        public CategoryUsersNullException() : base(message)
        {
        }
    }
}