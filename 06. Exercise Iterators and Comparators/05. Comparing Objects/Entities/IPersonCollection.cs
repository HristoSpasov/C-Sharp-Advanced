using _05.Comparing_Objects.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace _05.Comparing_Objects.Entities
{
    public class PersonCollection : IEnumerable<IPerson>
    {
        private IList<IPerson> persons;

        public PersonCollection()
        {
            this.persons = new List<IPerson>();
        }

        public void AddPerson(IPerson person)
        {
            this.persons.Add(person);
        }

        public IPerson GetPerson(int personId)
        {
            return this.persons[personId - 1];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.persons.GetEnumerator();
        }

        public IEnumerator<IPerson> GetEnumerator()
        {
            return this.persons.GetEnumerator();
        }
    }
}