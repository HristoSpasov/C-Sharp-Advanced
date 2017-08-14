using _01.Database.Entities;
using _01.Database.Utilities;
using NUnit.Framework;
using System;
using System.Text;

namespace _01.Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private const int DefaultSize = 16;
        private Database<int> db;

        [SetUp]
        public void InitializeDb()
        {
            EmptyArrayGenerator<int> arrGenerator = new EmptyArrayGenerator<int>();
            this.db = new Database<int>(arrGenerator.CreateArray(DefaultSize));
        }

        [Test]
        public void TestConstructorWithDifferentArraySize()
        {
            // Arrange
            EmptyArrayGenerator<int> arrGenerator = new EmptyArrayGenerator<int>();
            int[] arraySizes = new[] { 0, 1, 2, 20, 50, 100, 1000 };

            // Assert
            foreach (var size in arraySizes)
            {
                string expexted = this.GenerateExpectedOutput(size);
                this.db = new Database<int>(arrGenerator.CreateArray(size));
                this.FillDatabase(size);
                string result = this.CreateDatabaseResultFetchString();

                Assert.AreEqual(expexted, result, $"Creating database with {size}, was not successfull.");
            }
        }

        [Test]
        public void FetchFullDatabase()
        {
            // Arrange
            string expected = "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16";
            this.FillDatabase();

            // Act
            string result = this.CreateDatabaseResultFetchString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FetchHalfFullDatabase()
        {
            // Arrange
            string expected = "1 2 3 4 5 6 7 8";

            // Act
            for (int i = 0; i < DefaultSize / 2; i++)
            {
                this.db.Add(i + 1);
            }

            string result = this.CreateDatabaseResultFetchString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FetchEmptyDatabase()
        {
            // Arrange
            string expected = string.Empty;

            // Act
            this.db.Add(100);
            this.db.Remove();
            string result = this.CreateDatabaseResultFetchString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void RemoveElementFromEmptyCollection()
        {
            // Act
            this.db.Add(100);
            this.db.Remove();

            // Assert
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.db.Remove());
        }

        [Test]
        public void RemoveElemetAtTheLastIndexOfFullDatabase()
        {
            // Assert
            string expected = "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15";

            // Act
            this.FillDatabase();
            this.db.Remove();
            string result = this.CreateDatabaseResultFetchString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddSingleElementToEmptyDatabase()
        {
            // Act
            this.db.Add(10);
            string resultString = string.Join(" ", this.db.Fetch());

            // Assert
            Assert.AreEqual("10", resultString);
        }

        [Test]
        public void AddElemetsUntillDatabaseCapacityIsReached()
        {
            // Arrange
            string expected = "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16";

            // Act
            this.FillDatabase();
            string resultStr = this.CreateDatabaseResultFetchString();

            // Assert
            Assert.AreEqual(expected, resultStr);
        }

        [Test]
        public void AddElementToFullDatabase()
        {
            // Act
            this.FillDatabase();
            string resultStr = this.CreateDatabaseResultFetchString();

            // Assert
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.db.Add(1000));
            Assert.AreEqual("Stack is full.", ex.Message);
        }

        private string CreateDatabaseResultFetchString()
        {
            return string.Join(" ", this.db.Fetch());
        }

        private void FillDatabase()
        {
            for (int i = 0; i < DefaultSize; i++)
            {
                this.db.Add(i + 1);
            }
        }

        private void FillDatabase(int customSize)
        {
            for (int i = 0; i < customSize; i++)
            {
                this.db.Add(i + 1);
            }
        }

        private string GenerateExpectedOutput(int size)
        {
            StringBuilder expected = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                expected.Append(i + 1).Append(" ");
            }

            return expected.ToString().Trim();
        }
    }
}