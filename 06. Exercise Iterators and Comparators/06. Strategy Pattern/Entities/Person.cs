using _06.Strategy_Pattern.Interfaces;

namespace _06.Strategy_Pattern.Entities
{
    public class Person : IPerson
    {
        private readonly string name;
        private readonly int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name => this.name;

        public int Age => this.age;

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}