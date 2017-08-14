namespace _03.Detail_Printer
{
    using System.Collections.Generic;
    using _03.Detail_Printer.Contracts;
    using _03.Detail_Printer.Core;
    using _03.Detail_Printer.Entities;

    public class Program
    {
        public static void Main()
        {
            IList<IEmployee> emplyees = new List<IEmployee>()
            {
                new Employee("Ivan"),
                new Manager("Pesho", new List<string>()
                {
                    "Document 1",
                    "Document 2"
                })
            };

            DetailsPrinter printer = new DetailsPrinter(emplyees);
            printer.PrintDetails();
        }
    }
}