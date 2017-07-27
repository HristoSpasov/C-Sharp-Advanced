using _07.Equality_Logic.Interfaces;

namespace _07.Equality_Logic.Entitiy
{
    public class Person : IPerson
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
    }
}