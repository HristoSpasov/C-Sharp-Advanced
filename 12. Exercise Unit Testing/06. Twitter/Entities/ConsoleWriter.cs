namespace _06.Twitter.Entities
{
    using System;
    using _06.Twitter.Contracts;

    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLineOnConsole(ITweet tweet)
        {
            Console.WriteLine(tweet.RetrieveMessage());
        }
    }
}
