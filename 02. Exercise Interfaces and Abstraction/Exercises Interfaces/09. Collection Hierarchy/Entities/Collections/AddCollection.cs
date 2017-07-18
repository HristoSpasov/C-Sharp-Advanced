using _09.Collection_Hierarchy.Interfaces;
using System.Collections.Generic;

namespace _09.Collection_Hierarchy.Entities.Collections
{
    public class AddCollection : IAddCollection
    {
        private readonly IList<string> addCollection;

        public AddCollection()
        {
            this.addCollection = new List<string>(100);
        }

        public int Add(string addStr)
        {
            this.addCollection.Add(addStr);

            return this.addCollection.Count - 1;
        }
    }
}