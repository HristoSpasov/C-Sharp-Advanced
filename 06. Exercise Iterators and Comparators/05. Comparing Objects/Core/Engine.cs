using _05.Comparing_Objects.Entities;
using _05.Comparing_Objects.Interfaces;
using System;
using System.Linq;

namespace _05.Comparing_Objects.Core
{
    public class Engine
    {
        private bool isRunning;
        private PersonCollection personCollection;

        public Engine()
        {
            this.isRunning = true;
            this.personCollection = new PersonCollection();
        }

        public void Run()
        {
            while (this.isRunning)
            {
                string[] line = Console.ReadLine().Split();

                if (line[0] == "END")
                {
                    this.isRunning = false;
                    continue;
                }

                personCollection.AddPerson(new Person(line[0], int.Parse(line[1]), line[2]));
            }

            // Get person from list
            IPerson personToCompare = this.personCollection.GetPerson(int.Parse(Console.ReadLine()));

            // Get equal person
            int equalPersonsCount = this.personCollection.Count(p => p.CompareTo(personToCompare) == 0);

            // Print result
            Console.WriteLine(equalPersonsCount == 1
                ? "No matches"
                : $"{equalPersonsCount} {this.personCollection.Count() - equalPersonsCount} {this.personCollection.Count()}");
        }
    }
}