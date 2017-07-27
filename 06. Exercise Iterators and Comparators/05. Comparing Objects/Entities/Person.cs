using _05.Comparing_Objects.Interfaces;
using System;

namespace _05.Comparing_Objects.Entities
{
    public class Person : IPerson, IComparable<IPerson>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Town { get; private set; }

        public int CompareTo(IPerson other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var nameComparison = string.Compare(Name, other.Name, StringComparison.InvariantCulture);
            if (nameComparison != 0) return nameComparison;
            var ageComparison = Age.CompareTo(other.Age);
            if (ageComparison != 0) return ageComparison;
            return string.Compare(Town, other.Town, StringComparison.InvariantCulture);
        }
    }
}