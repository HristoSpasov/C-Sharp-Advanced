using _08.Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.Military_Elite.Entities
{
    public class LeutenantGeneral : ISoldier, IPrivate, ILeutenantGeneral
    {
        public LeutenantGeneral(string id, string firstName, string lastName, double salary)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Privates = new List<ISoldier>();
        }

        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public double Salary { get; private set; }
        public IList<ISoldier> Privates { get; private set; }

        public void AddPrivate(ISoldier soldier)
        {
            this.Privates.Add(soldier);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}{Environment.NewLine}");
            sb.Append(this.Privates.Any() ? $"Privates:{Environment.NewLine}  " : $"Privates:");
            sb.AppendLine($"{string.Join($"{Environment.NewLine}  ", this.Privates)}");

            return sb.ToString().Trim();
        }
    }
}