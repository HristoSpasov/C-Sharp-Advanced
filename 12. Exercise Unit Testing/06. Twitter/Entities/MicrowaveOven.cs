namespace _06.Twitter.Entities
{
    using _06.Twitter.Contracts;

    public class MicrowaveOven : IClient
    {
        private IServer server;
        private IConsoleWriter consoleWriter;

        public MicrowaveOven(IServer server, IConsoleWriter consoleWriter)
        {
            this.server = server;
            this.consoleWriter = consoleWriter;
        }

        public void ProcessTweet(ITweet tweet)
        {
            this.server.Tweet = tweet;
            this.consoleWriter.WriteLineOnConsole(tweet);
        }
    }
}
