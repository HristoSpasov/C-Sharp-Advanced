namespace _03.Detail_Printer.Entities
{
    using _03.Detail_Printer.Contracts;

    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.Name}";
        }
    }
}