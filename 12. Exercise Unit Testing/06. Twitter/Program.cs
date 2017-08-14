namespace _06.Twitter
{
    using _06.Twitter.Contracts;
    using _06.Twitter.Entities;

    public class Program
    {
        public static void Main()
        {
            ITweet tweet = new Tweeter();
            IServer server = new Server();
            IConsoleWriter writer = new ConsoleWriter();

            IClient microwaveoven = new MicrowaveOven(server, writer);
            microwaveoven.ProcessTweet(tweet);
        }
    }
}
