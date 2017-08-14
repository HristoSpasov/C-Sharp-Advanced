namespace _03.Detail_Printer.Entities
{
    using System.Collections.Generic;
    using _03.Detail_Printer.Contracts;

    public class Manager : IEmployee
    {
        public Manager(string name, ICollection<string> documents)
        {
            this.Name = name;
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public string Name { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.Name}; Documents: {string.Join(", ", this.Documents)};";
        }
    }
}