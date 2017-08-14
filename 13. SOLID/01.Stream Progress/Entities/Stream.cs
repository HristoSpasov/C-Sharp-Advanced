namespace _01.Stream_Progress.Entities
{
    using _01.Stream_Progress.Contracts;

    public abstract class Stream : IStream
    {
        private int length;
        private int bytesSent;

        protected Stream(int length, int bytesSent)
        {
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length
        {
            get { return this.length; }
            private set { this.length = value; }
        }

        public int BytesSent
        {
            get { return this.bytesSent; }
            private set { this.bytesSent = value; }
        }

        public override string ToString()
        {
            return $"{nameof(this.Length)}: {this.Length}; {nameof(this.BytesSent)}: {this.BytesSent};";
        }
    }
}