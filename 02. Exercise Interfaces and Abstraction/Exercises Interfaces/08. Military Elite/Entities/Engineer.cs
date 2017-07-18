using _08.Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.Military_Elite.Entities
{
    public class Engineer : ISoldier, IPrivate, ISpecialisedSoldier, IEngineer
    {
        private string corps;

        public Engineer(string id, string firstName, string lastName, double salary, string corps)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Corps = corps;
            this.Repairs = new List<IRepair>();
        }

        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public double Salary { get; private set; }

        public string Corps
        {
            get { return this.corps; }

            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException();
                }

                this.corps = value;
            }
        }

        public List<IRepair> Repairs { get; private set; }

        public void AddRepair(IRepair newRepair)
        {
            this.Repairs.Add(newRepair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}{Environment.NewLine}");
            sb.Append($"Corps: {this.Corps}{Environment.NewLine}");
            sb.Append(this.Repairs.Any() ? $"Repairs:{Environment.NewLine}  " : $"Repairs:");
            sb.Append($"{string.Join($"{Environment.NewLine}  ", this.Repairs)}");

            return sb.ToString().Trim();
        }
    }
}