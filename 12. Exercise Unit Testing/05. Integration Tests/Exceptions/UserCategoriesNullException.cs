using System;

namespace _05.Integration_Tests.Exceptions
{
    public class UserCategoriesNullException : Exception
    {
        private const string message = "User cannot with null categories collection cannot be assigned to category.";

        public UserCategoriesNullException() : base(message)
        {
        }
    }
}