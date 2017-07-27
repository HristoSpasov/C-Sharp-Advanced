using _07.Equality_Logic.Entitiy;
using System;

namespace _07.Equality_Logic.Core
{
    public class Engine
    {
        private readonly PersonCollection persons;

        public Engine()
        {
            this.persons = new PersonCollection();
        }

        public void Run()
        {
            // Read persons
            int personsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < personsCount; i++)
            {
                string[] args = Console.ReadLine().Split();

                persons.Add(new Person(args[0], int.Parse(args[1])));
            }

            // Print set sizes
            Console.WriteLine(persons.GetSetSizes());
        }
    }
}