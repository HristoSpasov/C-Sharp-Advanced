namespace _06.Twitter.Entities
{
    using _06.Twitter.Contracts;

    public class Tweeter : ITweet
    {
        public string RetrieveMessage()
        {
            return "Test Message!";
        }
    }
}
