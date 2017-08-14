using _04.WorkForce.Attributes;
using _04.WorkForce.Entities;
using _04.WorkForce.Entities.Emplyees;

namespace _04.WorkForce.Core.Commands
{
    [Command]
    public class Job : Command
    {
        public Job(string[] args, EmployeeCollection employeeCollection, JobCollection jobCollection) : base(args, employeeCollection, jobCollection)
        {
        }

        public override string Execute()
        {
            Employee employee = this.EmployeeCollection.GetEmplyee(this.Args[3]);
            Entities.Job job = new Entities.Job(this.Args[1], int.Parse(this.Args[2]), employee);
            this.JobCollection.AddJob(job);

            return null;
        }
    }
}