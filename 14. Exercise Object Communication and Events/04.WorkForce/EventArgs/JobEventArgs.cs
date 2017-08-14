namespace _04.WorkForce.EventArgs
{
    public class JobEventArgs : System.EventArgs
    {
        public JobEventArgs(string jobName)
        {
            this.Name = jobName;
        }

        public string Name { get; private set; }
    }
}