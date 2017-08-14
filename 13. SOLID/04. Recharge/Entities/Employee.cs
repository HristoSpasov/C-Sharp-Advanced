namespace _04.Recharge.Entities
{
    using System;
    using _04.Recharge.Contracts;

    public class Employee : IWorker, ISleeper
    {
        private string id;
        private int workingHours;

        public Employee(string id)
        {
            this.id = id;
        }

        public string Id
        {
            get { return this.id; }
        }

        public void Sleep()
        {
            Console.WriteLine("I am sleeping!");
        }

        public void Work(int hours)
        {
            this.workingHours += hours;
        }
    }
}