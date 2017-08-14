using _05.Integration_Tests.Contracts;
using System.Collections.Generic;

namespace _05.Integration_Tests.Entities
{
    public class User : IUser
    {
        private string name;
        private IEnumerable<ICategory> categories;

        public string Name
        {
            get { return this.name; }
        }

        public IEnumerable<ICategory> Categories
        {
            get { return this.categories; }
        }
    }
}