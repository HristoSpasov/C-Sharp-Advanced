using _04.WorkForce.Attributes;
using _04.WorkForce.Entities;
using _04.WorkForce.Entities.Emplyees;

namespace _04.WorkForce.Core.Commands
{
    [Command]
    public class StandartEmployee : Command
    {
        public StandartEmployee(string[] args, EmployeeCollection employeeCollection, JobCollection jobCollection) : base(args, employeeCollection, jobCollection)
        {
        }

        public override string Execute()
        {
            this.EmployeeCollection.AddEmployee(new StandartTimeEmployee(this.Args[1]));

            return null;
        }
    }
}