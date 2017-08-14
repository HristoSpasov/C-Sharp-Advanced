using System;

namespace _05.Integration_Tests.Exceptions
{
    public class UserExistsException : Exception
    {
        private const string message = "User list in target category '{1}', already contains user with '{0}' name.";

        public UserExistsException(string userName, string categotyName)
            : base(string.Format(message, userName, categotyName))
        {
        }
    }
}