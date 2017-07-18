using _09.Collection_Hierarchy.Entities.Collections;
using _09.Collection_Hierarchy.Interfaces;

namespace _09.Collection_Hierarchy.Core
{
    public class Manager
    {
        private readonly AddCollection addCollection;
        private readonly AddRemoveCollection addRemoveCollection;
        private readonly MyList myList;

        public Manager()
        {
            this.addCollection = new AddCollection();
            this.addRemoveCollection = new AddRemoveCollection();
            this.myList = new MyList();
        }

        public IAddCollection AddCollection => this.addCollection;

        public IAddRemoveCollection AddRemoveCollection => this.addRemoveCollection;

        public IMyList MyList => this.myList;
    }
}