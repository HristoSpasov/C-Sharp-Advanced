using _09.Collection_Hierarchy.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _09.Collection_Hierarchy.Entities.Collections
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private readonly List<string> addRemoveCollection;

        public AddRemoveCollection()
        {
            this.addRemoveCollection = new List<string>(100);
        }

        public int Add(string addStr)
        {
            this.addRemoveCollection.Insert(0, addStr);

            return 0; // This collection always adds to 0 pozition;
        }

        public string Remove()
        {
            string strToRemove = this.addRemoveCollection.Last();
            this.addRemoveCollection.RemoveAt(this.addRemoveCollection.Count - 1);

            return strToRemove;
        }
    }
}