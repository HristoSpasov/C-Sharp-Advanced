namespace _03.Detail_Printer.Core
{
    using System;
    using System.Collections.Generic;
    using _03.Detail_Printer.Contracts;

    public class DetailsPrinter
    {
        private readonly IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IEmployee employee in this.employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}