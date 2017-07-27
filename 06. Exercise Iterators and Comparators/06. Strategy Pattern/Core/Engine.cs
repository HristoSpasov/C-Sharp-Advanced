using _06.Strategy_Pattern.Entities;
using System;

namespace _06.Strategy_Pattern.Core
{
    public class Engine
    {
        private readonly PersoCollection persons;

        public Engine()
        {
            this.persons = new PersoCollection();
        }

        public void Run()
        {
            // Read persons
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] personArgs = Console.ReadLine().Split();

                persons.Add(new Person(personArgs[0], int.Parse(personArgs[1])));
            }

            // Print sorted persons
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}