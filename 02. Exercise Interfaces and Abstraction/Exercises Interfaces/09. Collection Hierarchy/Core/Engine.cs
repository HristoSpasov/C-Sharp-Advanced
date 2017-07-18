using System;
using System.Text;

namespace _09.Collection_Hierarchy.Core
{
    public class Engine
    {
        private Manager manager;
        private StringBuilder output;

        public Engine()
        {
            this.manager = new Manager();
            this.output = new StringBuilder();
        }

        public void Run()
        {
            // Read input
            string[] strings = Console.ReadLine().Split();
            int removeOperations = int.Parse(Console.ReadLine());

            // Add data to all collections
            foreach (var str in strings)
            {
                this.output.Append($"{this.manager.AddCollection.Add(str)} ");
            }

            this.output.AppendLine();

            foreach (var str in strings)
            {
                this.output.Append($"{this.manager.AddRemoveCollection.Add(str)} ");
            }

            this.output.AppendLine();

            foreach (var str in strings)
            {
                this.output.Append($"{this.manager.MyList.Add(str)} ");
            }

            this.output.AppendLine();

            // Remove data from AddRemoveCollection
            for (int i = 0; i < removeOperations; i++)
            {
                this.output.Append($"{this.manager.AddRemoveCollection.Remove()} ");
            }

            this.output.AppendLine();

            // Remove data from MyList
            for (int i = 0; i < removeOperations; i++)
            {
                this.output.Append($"{this.manager.MyList.Remove()} ");
            }

            // Print output
            Console.WriteLine(this.output.ToString().Trim());
        }
    }
}