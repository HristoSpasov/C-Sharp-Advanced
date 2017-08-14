using System;

namespace _05.Integration_Tests.Exceptions
{
    public class UserNullException : Exception
    {
        private const string message = "Cannot assign null user object";

        public UserNullException() : base(message)
        {
        }
    }
}