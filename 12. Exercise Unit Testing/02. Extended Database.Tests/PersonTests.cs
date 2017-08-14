using _02.Extended_Database.Entities;
using NUnit.Framework;
using System;

namespace _02.Extended_Database.Tests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void CreateValidPersonInnstance()
        {
            // Arrange
            long id = 1;
            string name = "Pesho";

            // Act
            Person person = new Person(id, name);

            // Assert
            Assert.IsTrue(person != null, "Was unable to create person instance with valid data");
        }

        [Test]
        public void CreatePersonWithInvalidName()
        {
            // Arrange
            long id = 1;
            string name = string.Empty;

            // Assert
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new Person(id, name), "Making person with invalid name, does not throw expected exception.");
            Assert.AreEqual("Cannot create person with empty name", ex.ParamName, "Invalid exception message!");
        }

        [Test]
        public void CreatePersonWithInvalidId()
        {
            // Arrange
            long id = -1;
            string name = "Ivan";

            // Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Person(id, name), "Does not throw exception when trying to make person with invalid id.");
            Assert.AreEqual("Id cannot be negative!", ex.ParamName, "Invalid exception message thrown.");
        }
    }
}