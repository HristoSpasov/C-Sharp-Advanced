using _05.Integration_Tests.Contracts;
using System.Collections.Generic;

namespace _05.Integration_Tests.Entities
{
    public class Category : ICategory
    {
        private string name;
        private IEnumerable<IUser> users;
        private ICategory childCategory;

        public string Name
        {
            get { return this.name; }
        }

        public IEnumerable<IUser> Users
        {
            get { return this.users; }
        }

        public ICategory ChildCategory
        {
            get { return this.childCategory; }
            set { this.childCategory = value; }
        }
    }
}