using _04.WorkForce.Attributes;
using _04.WorkForce.Entities;

namespace _04.WorkForce.Core.Commands
{
    [Command]
    public class PartTimeEmployee : Command
    {
        public PartTimeEmployee(string[] args, EmployeeCollection employeeCollection, JobCollection jobCollection) : base(args, employeeCollection, jobCollection)
        {
        }

        public override string Execute()
        {
            this.EmployeeCollection.AddEmployee(new Entities.Emplyees.PartTimeEmployee(this.Args[1]));

            return null;
        }
    }
}