using _09.Collection_Hierarchy.Interfaces;
using System.Collections.Generic;

namespace _09.Collection_Hierarchy.Entities.Collections
{
    public class MyList : IMyList
    {
        private readonly IList<string> myList;

        public MyList()
        {
            this.myList = new List<string>(100);
        }

        public int Add(string addStr)
        {
            this.myList.Insert(0, addStr);

            return 0; // This collection always adds to 0 pozition;
        }

        public string Remove()
        {
            string strToRemove = this.myList[0];
            this.myList.RemoveAt(0);

            return strToRemove;
        }

        public int Used()
        {
            return this.myList.Count;
        }
    }
}