using _04.WorkForce.Entities;

namespace _04.WorkForce.Core.Commands
{
    public abstract class Command
    {
        private string[] args;
        private EmployeeCollection employeeCollection;
        private JobCollection jobCollection;

        protected Command(string[] args, EmployeeCollection employeeCollection, JobCollection jobCollection)
        {
            this.args = args;
            this.employeeCollection = employeeCollection;
            this.jobCollection = jobCollection;
        }

        protected string[] Args
        {
            get { return this.args; }
        }

        protected EmployeeCollection EmployeeCollection
        {
            get { return this.employeeCollection; }
        }

        protected JobCollection JobCollection
        {
            get { return this.jobCollection; }
        }

        public abstract string Execute();
    }
}