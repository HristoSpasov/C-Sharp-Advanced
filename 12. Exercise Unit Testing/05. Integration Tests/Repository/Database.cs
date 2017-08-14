using _05.Integration_Tests.Contracts;
using System.Collections.Generic;

namespace _05.Integration_Tests.Repository
{
    public class Database : IDatabase
    {
        private IEnumerable<ICategory> categories;
        private IEnumerable<IUser> users;

        public IEnumerable<ICategory> Categories
        {
            get { return this.categories; }
        }

        public IEnumerable<IUser> Users
        {
            get { return this.users; }
        }
    }
}