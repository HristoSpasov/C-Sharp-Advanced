using _06.Strategy_Pattern.Comparators;
using _06.Strategy_Pattern.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace _06.Strategy_Pattern.Core
{
    public class PersoCollection : IEnumerable<IPerson>
    {
        private SortedSet<IPerson> personByNameLengthAndFirstNameLetter;
        private SortedSet<IPerson> personsByAge;

        public PersoCollection()
        {
            this.personByNameLengthAndFirstNameLetter = new SortedSet<IPerson>(new PersonByNameLengthAndFirstNameLetterComparator());
            this.personsByAge = new SortedSet<IPerson>(new PersonsByAgeComparator());
        }

        public void Add(IPerson person)
        {
            this.personByNameLengthAndFirstNameLetter.Add(person);
            this.personsByAge.Add(person);
        }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var person in personByNameLengthAndFirstNameLetter)
            {
                yield return person;
            }

            foreach (var person in personsByAge)
            {
                yield return person;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}