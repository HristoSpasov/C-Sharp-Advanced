using _04.WorkForce.Attributes;
using _04.WorkForce.Entities;

namespace _04.WorkForce.Core.Commands
{
    [Command]
    public class Pass : Command
    {
        public Pass(string[] args, EmployeeCollection employeeCollection, JobCollection jobCollection) : base(args, employeeCollection, jobCollection)
        {
        }

        public override string Execute()
        {
            this.JobCollection.JobsUpdate();

            return null;
        }
    }
}