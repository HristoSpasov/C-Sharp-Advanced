namespace _06.Twitter.Entities
{
    using _06.Twitter.Contracts;

    public class Server : IServer
    {
        public ITweet Tweet { get; set; }
    }
}
