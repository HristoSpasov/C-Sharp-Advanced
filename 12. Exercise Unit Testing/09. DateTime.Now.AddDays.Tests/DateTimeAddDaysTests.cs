using NUnit.Framework;

namespace _09.DateTime.Now.AddDays.Tests
{
    using System;
    using System.Globalization;
    using Moq;
    using _09.DateTime.Now.AddDays__.Contracts;

    [TestFixture]
    public class DateTimeAddDaysTests
    {
        private Mock<IDateTime> mockDate;

        [SetUp]
        public void Initialize()
        {
            this.mockDate = new Mock<IDateTime>();
        }

        [Test]
        public void TestAddingDayToTheMiddleOfTheMonth()
        {
            // Arrange
            DateTime initialDate = DateTime.ParseExact("16/07/2017", "d/M/yyyy", CultureInfo.InvariantCulture);
            DateTime expectedDate = DateTime.ParseExact("17/07/2017", "d/M/yyyy", CultureInfo.InvariantCulture);

            // Act
            this.mockDate.Setup(dt => dt.AddDays(It.IsAny<int>())).Returns(() => initialDate.AddDays(1));

            // Arrange
            Assert.AreEqual(expectedDate, this.mockDate.Object.AddDays(4343), "Adding a day in the middle of the month does not work correctly!");
        }

        [Test]
        public void TestAddingDayToTheEndOfTheMonth()
        {
            // Arrange
            DateTime initialDate = DateTime.ParseExact("31/07/2017", "d/M/yyyy", CultureInfo.InvariantCulture);
            DateTime expectedDate = DateTime.ParseExact("01/08/2017", "d/M/yyyy", CultureInfo.InvariantCulture);

            // Act
            this.mockDate.Setup(dt => dt.AddDays(It.IsAny<int>())).Returns(() => initialDate.AddDays(1));

            // Arrange
            Assert.AreEqual(expectedDate, this.mockDate.Object.AddDays(4343), "Adding a day in the end of the month does not work correctly!");
        }

        [Test]
        public void TestAddingNegativeFiveDaysGoingToPreviousMonth()
        {
            // Arrange
            DateTime initialDate = DateTime.ParseExact("01/07/2017", "d/M/yyyy", CultureInfo.InvariantCulture);
            DateTime expectedDate = DateTime.ParseExact("26/06/2017", "d/M/yyyy", CultureInfo.InvariantCulture);

            // Act
            this.mockDate.Setup(dt => dt.AddDays(It.IsAny<int>())).Returns(() => initialDate.AddDays(-5));

            // Arrange
            Assert.AreEqual(expectedDate, this.mockDate.Object.AddDays(4343), "Adding -5 days to the begining of the month does not work correctly!");
        }

        [Test]
        public void TestAddingDayToTheEndOfFebruaryInLeapYear()
        {
            // Arrange
            DateTime initialDate = DateTime.ParseExact("28/02/2016", "d/M/yyyy", CultureInfo.InvariantCulture);
            DateTime expectedDate = DateTime.ParseExact("29/02/2016", "d/M/yyyy", CultureInfo.InvariantCulture);

            // Act
            this.mockDate.Setup(dt => dt.AddDays(It.IsAny<int>())).Returns(() => initialDate.AddDays(1));

            // Arrange
            Assert.AreEqual(expectedDate, this.mockDate.Object.AddDays(4343), "Adding day to the end february in leap year does not work correctly!");
        }

        [Test]
        public void TestAddingDayToTheEndOfFebruaryInNonLeapYear()
        {
            // Arrange
            DateTime initialDate = DateTime.ParseExact("28/02/2017", "d/M/yyyy", CultureInfo.InvariantCulture);
            DateTime expectedDate = DateTime.ParseExact("01/03/2017", "d/M/yyyy", CultureInfo.InvariantCulture);

            // Act
            this.mockDate.Setup(dt => dt.AddDays(It.IsAny<int>())).Returns(() => initialDate.AddDays(1));

            // Arrange
            Assert.AreEqual(expectedDate, this.mockDate.Object.AddDays(4343), "Adding day to the end february in non leap year does not work correctly!");
        }

        [Test]
        public void TestAddingDayToDateTimeMin()
        {
            // Arrange
            DateTime initialDate = DateTime.MinValue;
            DateTime expectedDate = DateTime.ParseExact("02/01/0001", "d/M/yyyy", CultureInfo.InvariantCulture);

            // Act
            this.mockDate.Setup(dt => dt.AddDays(It.IsAny<int>())).Returns(() => initialDate.AddDays(1));

            // Arrange
            Assert.AreEqual(expectedDate, this.mockDate.Object.AddDays(4343), "Adding day to date time min does not work correctly!");
        }

        [Test]
        public void TestAddingDayToDateTimeMax()
        {
            // Arrange
            DateTime initialDate = DateTime.MaxValue;

            // Act
            this.mockDate.Setup(dt => dt.AddDays(It.IsAny<int>())).Returns(() => initialDate.AddDays(1));

            // Arrange
            Assert.Throws<ArgumentOutOfRangeException>(() => this.mockDate.Object.AddDays(4343), "Adding day to date time max does not work correctly!");
        }

        [Test]
        public void TestSubtractDayFromDateTimeMin()
        {
            // Arrange
            DateTime initialDate = DateTime.MinValue;

            // Act
            this.mockDate.Setup(dt => dt.AddDays(It.IsAny<int>())).Returns(() => initialDate.AddDays(-1));

            // Arrange
            Assert.Throws<ArgumentOutOfRangeException>(() => this.mockDate.Object.AddDays(4343), "Subtracting day to date time min does not work correctly!");
        }

        [Test]
        public void TestSubtractDayFromDateTimeMax()
        {
            // Arrange
            DateTime initialDate = DateTime.MaxValue;
            DateTime expectedDate = DateTime.ParseExact("30/12/9999", "d/M/yyyy", CultureInfo.InvariantCulture);

            // Act
            this.mockDate.Setup(dt => dt.AddDays(It.IsAny<int>())).Returns(() => initialDate.AddDays(-1));

            // Arrange
            Assert.AreEqual(expectedDate.ToString("MM/dd/yyyy"), this.mockDate.Object.AddDays(4343).ToString("MM/dd/yyyy"), "Subtracting day to date time max does not work correctly!");
        }
    }
}
