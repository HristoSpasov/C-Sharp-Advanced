namespace _01.Stream_Progress
{
    using _01.Stream_Progress.Entities;

    public class Music : Stream
    {
        private string artist;
        private string album;

        public Music(string artist, string album, int length, int bytesSent) : base(length, bytesSent)
        {
            this.artist = artist;
            this.album = album;
        }

        public string Artist
        {
            get { return this.artist; }
            private set { this.artist = value; }
        }

        public string Album
        {
            get { return this.album; }
            private set { this.album = value; }
        }

        public override string ToString()
        {
            return $"{nameof(this.Artist)}: {this.artist}; {nameof(this.Album)}: {this.album}; {base.ToString()}";
        }
    }
}