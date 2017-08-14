using System;

namespace _05.Integration_Tests.Exceptions
{
    public class UserNameException : Exception
    {
        private const string message = "User name cannot be null or whitespace!";

        public UserNameException() : base(message)
        {
        }
    }
}