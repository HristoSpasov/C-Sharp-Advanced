using _10.Explicit_Interfaces.Entities.Interfaces;

namespace _10.Explicit_Interfaces.Entities
{
    public class Citizen : IPerson, IResident
    {
        private string name;
        private int age;
        private string country;

        public Citizen(string name, string country, int age)
        {
            this.name = name;
            this.age = age;
            this.country = country;
        }

        string IPerson.Name
        {
            get { return this.name; }
        }

        public string Country
        {
            get { return country; }
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.name}";
        }

        public int Age
        {
            get { return age; }
        }

        string IResident.Name
        {
            get { return name; }
        }

        string IPerson.GetName()
        {
            return $"{this.name}";
        }
    }
}