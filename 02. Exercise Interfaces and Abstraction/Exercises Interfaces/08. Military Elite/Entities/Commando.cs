using _08.Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.Military_Elite.Entities
{
    public class Commando : ISoldier, IPrivate, ISpecialisedSoldier, ICommando
    {
        private string corps;

        public Commando(string id, string firstName, string lastName, double salary, string corps)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Corps = corps;
            this.Missions = new List<IMission>();
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

        public List<IMission> Missions { get; private set; }

        public void AddRepair(IMission newMission)
        {
            this.Missions.Add(newMission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}{Environment.NewLine}");
            sb.Append($"Corps: {this.Corps}{Environment.NewLine}");
            sb.Append(this.Missions.Any() ? $"Missions:{Environment.NewLine}  " : $"Missions:");
            sb.Append($"{string.Join($"{Environment.NewLine}  ", this.Missions)}");

            return sb.ToString().Trim();
        }
    }
}