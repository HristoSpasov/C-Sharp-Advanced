namespace _01.Stream_Progress
{
    using _01.Stream_Progress.Entities;

    public class File : Stream
    {
        private string name;

        public File(string name, int length, int bytesSent) : base(length, bytesSent)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public override string ToString()
        {
            return $"{nameof(this.Name)}: {this.Name}; {base.ToString()}";
        }
    }
}