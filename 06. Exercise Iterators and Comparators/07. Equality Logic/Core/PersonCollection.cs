using _07.Equality_Logic.Comparers;
using _07.Equality_Logic.Interfaces;
using System;
using System.Collections.Generic;

namespace _07.Equality_Logic.Core
{
    public class PersonCollection
    {
        private readonly SortedSet<IPerson> sortedSetPersons;

        private readonly HashSet<IPerson> hashSetPersons;

        public PersonCollection()
        {
            this.sortedSetPersons = new SortedSet<IPerson>(new PersonComparer());
            this.hashSetPersons = new HashSet<IPerson>(new PersonComparer());
        }

        public void Add(IPerson person)
        {
            this.sortedSetPersons.Add(person);
            this.hashSetPersons.Add(person);
        }

        public string GetSetSizes()
        {
            return this.sortedSetPersons.Count + Environment.NewLine + this.hashSetPersons.Count;
        }
    }
}