using NUnit.Framework;

namespace _06.Twiter.Tests
{
    using Moq;
    using _06.Twitter.Contracts;
    using _06.Twitter.Entities;

    [TestFixture]
    public class TwitterTests
    {
        private Mock<ITweet> tweetMock;
        private Mock<IServer> server;
        private IConsoleWriter writer;
        private IClient client;

        [SetUp]
        public void Initialize()
        {
            this.tweetMock = new Mock<ITweet>();
            this.server = new Mock<IServer>();
            this.writer = new ConsoleWriter();
            this.client = new MicrowaveOven(this.server.Object, this.writer);
        }

        [Test]
        public void TestMethod()
        {
            this.tweetMock.Setup(rm => rm.RetrieveMessage()).Returns("Test!");
        }
    }
}
