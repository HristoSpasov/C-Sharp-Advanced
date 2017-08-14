using System;

namespace _05.Integration_Tests.Exceptions
{
    public class ChildCategoryNotAddedAsBaseCategory : Exception
    {
        private const string message =
                "Child category '{0}' was not added in categories collection because category with that name already exists.";

        public ChildCategoryNotAddedAsBaseCategory(string name)
            : base(string.Format(message, name))
        {
        }
    }
}