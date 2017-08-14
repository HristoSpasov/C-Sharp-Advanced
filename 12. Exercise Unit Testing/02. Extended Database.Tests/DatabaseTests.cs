using _02.Extended_Database.Entities;
using _02.Extended_Database.Utilities;
using NUnit.Framework;
using System;
using System.Text;

namespace _02.Extended_Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private const int DefaultSize = 16;
        private Database<Person> db;

        [SetUp]
        public void InitializeDb()
        {
            EmptyArrayGenerator<Person> arrGenerator = new EmptyArrayGenerator<Person>();
            this.db = new Database<Person>(arrGenerator.CreateArray(DefaultSize));
        }

        [Test]
        public void SearchForValidId()
        {
            // Arrange
            this.FillDatabase();

            // Act
            Person searchPerson = this.db.FindById(DefaultSize + 10 - 1);
            string expectedName = $"Ivan{DefaultSize - 1}";

            // Assert
            Assert.AreEqual(DefaultSize + 10 - 1, searchPerson.Id, "No person with expected id was found");
            Assert.AreEqual(expectedName, searchPerson.UserName, "The name of the found person does not match to the expected name found person");
        }

        [Test]
        public void SearchForNonExistingId()
        {
            // Arrange
            this.db.Add(new Person(1, "Ivan"));

            // Assert
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.db.FindById(2));
            Assert.AreEqual("No person found with such id", ex.Message, "Incorrect exception message!");
        }

        [Test]
        public void SearchForInvalidId()
        {
            // Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => this.db.FindById(-5));
            Assert.AreEqual("Id cannot be negative.", ex.ParamName);
        }

        [Test]
        public void SearchForValidUserName()
        {
            // Arrange
            this.FillDatabase();

            // Act
            Person searchPerson = this.db.FindByUsername($"Ivan{DefaultSize - 1}");

            // Assert
            Assert.IsTrue(searchPerson != null, "No person was found in database with specified name");
        }

        [Test]
        public void SearchForInvalidUserName()
        {
            // Arrange
            this.db.Add(new Person(1, "Ivan"));

            // Assert
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.db.FindByUsername("Pesho"));
            Assert.AreEqual("No person found with such user name", ex.Message, "Invalid exception string");
        }

        [Test]
        public void FindByUserNameWithInvalidSearchString()
        {
            // Assert
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => this.db.FindByUsername(string.Empty));
            Assert.AreEqual("Username cannot be null or empty.", ex.ParamName, "Invalid exception string");
        }

        [Test]
        public void TestConstructorWithDifferentArraySize()
        {
            // Arrange
            EmptyArrayGenerator<Person> arrGenerator = new EmptyArrayGenerator<Person>();
            int[] arraySizes = new[] { 0, 1, 2, 20, 50, 100, 1000 };

            // Assert
            foreach (var size in arraySizes)
            {
                string expexted = this.GenerateExpectedOutput(size);
                this.db = new Database<Person>(arrGenerator.CreateArray(size));
                this.FillDatabase(size);
                string result = this.CreateDatabaseResultFetchString();

                Assert.AreEqual(expexted, result, $"Creating database with {size}, was not successfull.");
            }
        }

        [Test]
        public void FetchFullDatabase()
        {
            // Arrange
            string expected = this.GenerateExpectedOutput();
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
            string expected = this.GenerateExpectedOutput(DefaultSize / 2);

            // Act
            for (int i = 0; i < DefaultSize / 2; i++)
            {
                Person person = new Person(i + 10, "Ivan" + i);
                this.db.Add(person);
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
            this.db.Add(new Person(1, "Ivan"));
            this.db.Remove();
            string result = this.CreateDatabaseResultFetchString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void RemoveElementFromEmptyCollection()
        {
            // Act
            this.db.Add(new Person(1, "Ivan"));
            this.db.Remove();

            // Assert
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.db.Remove());
        }

        [Test]
        public void RemoveElemetAtTheLastIndexOfFullDatabase()
        {
            // Assert
            string expected = this.GenerateExpectedOutput(DefaultSize - 1);

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
            this.db.Add(new Person(1, "Ivan"));
            string resultString = this.CreateDatabaseResultFetchString();

            // Assert
            Assert.AreEqual("(Id: 1, UserName: Ivan)", resultString);
        }

        [Test]
        public void AddElemetsUntillDatabaseCapacityIsReached()
        {
            // Arrange
            string expected = this.GenerateExpectedOutput();

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
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.db.Add(new Person(1, "Ivan")));
            Assert.AreEqual("Stack is full.", ex.Message);
        }

        private string CreateDatabaseResultFetchString()
        {
            StringBuilder fetchBuilder = new StringBuilder();

            Person[] fetch = this.db.Fetch();

            for (int i = 0; i < fetch.Length; i++)
            {
                fetchBuilder.Append(fetch[i]).Append(" ");
            }

            return fetchBuilder.ToString().Trim();
        }

        private void FillDatabase(int customSize = DefaultSize)
        {
            for (int i = 0; i < customSize; i++)
            {
                Person person = new Person(i + 10, "Ivan" + i);
                this.db.Add(person);
            }
        }

        private string GenerateExpectedOutput(int size = DefaultSize)
        {
            StringBuilder expected = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                Person person = new Person(i + 10, "Ivan" + i);
                expected.Append(person.ToString()).Append(" ");
            }

            return expected.ToString().Trim();
        }
    }
}