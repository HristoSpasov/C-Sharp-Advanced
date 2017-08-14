using System;
using _04.WorkForce.Core.Commands;
using _04.WorkForce.Entities;
using _04.WorkForce.Factories;

namespace _04.WorkForce.Core
{
    public class Engine
    {
        private readonly EmployeeCollection employeeCollection;
        private readonly JobCollection jobCollection;

        public Engine(EmployeeCollection employeeCollection, JobCollection jobCollection)
        {
            this.employeeCollection = employeeCollection;
            this.jobCollection = jobCollection;
        }

        public void Run()
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] args = line.Split();

                Command cmd = new CommandFactory().GetCommand(args, this.employeeCollection, this.jobCollection);
                string result = cmd.Execute();

                if (!string.IsNullOrEmpty(result))
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}