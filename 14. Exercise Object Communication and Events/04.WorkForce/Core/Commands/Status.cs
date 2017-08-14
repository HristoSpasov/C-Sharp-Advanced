using _04.WorkForce.Attributes;
using _04.WorkForce.Entities;

namespace _04.WorkForce.Core.Commands
{
    [Command]
    public class Status : Command
    {
        public Status(string[] args, EmployeeCollection employeeCollection, JobCollection jobCollection) : base(args, employeeCollection, jobCollection)
        {
        }

        public override string Execute()
        {
            return this.JobCollection.JobsStatus();
        }
    }
}