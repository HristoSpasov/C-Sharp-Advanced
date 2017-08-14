using _04.WorkForce.Entities.Emplyees;
using _04.WorkForce.EventArgs;

namespace _04.WorkForce.Entities
{
    public delegate void JobFinishedHangler(object sourse, JobEventArgs args);

    public class Job
    {
        public event JobFinishedHangler JobFinished;

        private readonly Employee employee;
        private string name;
        private int requredHours;
        private bool isDone;

        public Job(string name, int requredHours, Employee employee)
        {
            this.Name = name;
            this.requredHours = requredHours;
            this.employee = employee;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int RemainingHours
        {
            get { return this.requredHours; }
            private set
            {
                if (value <= 0)
                {
                    if (JobFinished != null)
                    {
                        JobFinished(this, new JobEventArgs(this.Name));
                    }
                }

                this.requredHours = value;
            }
        }

        public bool IsDone
        {
            get { return this.isDone; }
            set { this.isDone = value; }
        }

        public void Update()
        {
            this.RemainingHours = this.RemainingHours - this.employee.WorkingHoursPerWeek;
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.RemainingHours}";
        }
    }
}