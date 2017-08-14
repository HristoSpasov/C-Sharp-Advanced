namespace SimpleJudje.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using SimpleJudje.Contracts;
    using SimpleJudje.DataStructures;

    [TestFixture]
    public class OrderDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void Initialize()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            // Act
            this.names = new SimpleSortedList<string>();

            // Assert
            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            // Act
            this.names = new SimpleSortedList<string>(20);

            // Arrange
            Assert.AreEqual(20, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            // Act
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);

            // Assert
            Assert.AreEqual(30, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            // Act
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            // Assert
            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestAddIncreasesSize()
        {
            // Act
            this.names.Add("Nasko");

            // Assert
            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            // Arrange
            string expectedOutput = "Balkan, Georgi, Rosen";

            // Act
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");

            string actualOutput = this.GetActualOutput();

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void TesAddingMoreThanInitialCapacity()
        {
            // Assert
            int expectedSize = 17;
            int countOfElementsToFillCollection = this.names.Capacity;

            // Act
            this.FillWithElements(countOfElementsToFillCollection);
            this.names.Add("Ivan17");

            // Assert
            Assert.AreEqual(expectedSize, this.names.Size);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            // Arrange
            int expectedSize = 2;
            IList<string> elementsToAdd = new List<string>() { "1", "2" };

            // Act
            this.names.AdAll(elementsToAdd);

            // Assert
            Assert.AreEqual(expectedSize, this.names.Size);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            // Arrange
            IList<string> elementsToAdd = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.AdAll(elementsToAdd));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            // Arrange
            string expectedOutput = "Balkan, Georgi, Rosen";
            IList<string> listToAdd = new List<string>() { "Rosen", "Georgi", "Balkan" };

            // Act
            this.names.AdAll(listToAdd);
            string actualOutput = this.GetActualOutput();

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            // Arrange
            string elementToAddAndRemove = "Ivan";
            int expectedSize = 0;

            // Act
            this.names.Add(elementToAddAndRemove);
            this.names.Remove(elementToAddAndRemove);

            // Assert
            Assert.AreEqual(expectedSize, this.names.Size);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            // Act
            this.names.Add("Ivan");
            this.names.Add("Nasko");
            this.names.Remove("Ivan");

            // Assert
            Assert.IsFalse(this.names.Remove("Ivan"));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));
        }

        [Test]
        public void TestJoinWithNull()
        {
            // Arrange
            IList<string> listToAdd = new List<string>() { "Rosen", "Georgi", "Balkan" };

            // Act
            this.names.AdAll(listToAdd);

            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            // Arrange
            string expectedOutput = "Balkan, Georgi, Rosen";
            IList<string> listToAdd = new List<string>() { "Rosen", "Georgi", "Balkan" };

            // Act
            this.names.AdAll(listToAdd);
            string actualOutput = this.names.JoinWith(", ");

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        private void FillWithElements(int countOfElementsToFillCollection)
        {
            for (int i = 0; i < countOfElementsToFillCollection; i++)
            {
                this.names.Add("Ivan" + (i + 1));
            }
        }

        private string GetActualOutput()
        {
            return string.Join(", ", this.names).TrimEnd(", ".ToCharArray());
        }
    }
}