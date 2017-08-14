using _03.Iterator_Test.Exceptions;
using _03.Iterator_Test.Generics;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace _03.Iterator_Test.Tests
{
    [TestFixture]
    public class ListyIteratorTests
    {
        private const int DefaultTestSize = 5;
        private ListyIterator<string> testCollection;

        [SetUp]
        public void DataInitialize()
        {
            this.testCollection = new ListyIterator<string>(this.TestArrayGenerator());
        }

        [Test]
        public void TestConstructorWithoutAnyElementsInTheInputArray()
        {
            // Arrrange
            this.testCollection = new ListyIterator<string>();
            string[] internalCollection = this.GetInternalCollection();

            // Assert
            Assert.AreEqual(0, internalCollection.Length, $"The length of inner collection array is expected to be 0!");
        }

        [Test]
        public void TestConstructowWithSomeElements()
        {
            // Arrange
            Type collectionType = this.testCollection.GetType();
            string[] internalCollection = this.GetInternalCollection();

            // Assert
            Assert.AreEqual(5, internalCollection.Length, $"The length of inner collection array is expected to be {DefaultTestSize}!");
        }

        [Test]
        public void InnerCollectionHasNextElement()
        {
            // Arrange
            string[] innerCollection = this.GetInternalCollection();
            int internalIndex = this.GetInternalIndex();

            // Assert
            Assert.IsTrue(this.testCollection.HasNext() && (internalIndex < innerCollection.Length), "Internal index is set to last element. Collection does not have next element.");
        }

        [Test]
        public void InnerCollectionDoesNotHaveNextElement()
        {
            // Arrange
            string[] innerCollection = this.GetInternalCollection();
            this.SetInternalIndex();
            int internalIndex = this.GetInternalIndex();

            // Assert
            Assert.IsTrue(!this.testCollection.HasNext() && (internalIndex == innerCollection.Length - 1), "Internal index is not set to last element in collection. Collection has more elements.");
        }

        [Test]
        public void CanMoveOnNextElement()
        {
            // Arrange
            int internalIndex = this.GetInternalIndex();

            // Assert
            Assert.IsTrue(this.testCollection.Move() && this.GetInternalIndex() - internalIndex == 1, "Was not able to move on next element.");
        }

        [Test]
        public void CannotMoveOnNextElement()
        {
            // Arrange
            this.SetInternalIndex();

            // Assert
            Assert.IsTrue(!this.testCollection.Move() && this.GetInternalIndex() == DefaultTestSize - 1, "Current internal index is set to last element index. Cannot move further.");
        }

        [Test]
        public void PrintElementFromCollection()
        {
            // Arrange
            string expectedResult = this.TestArrayGenerator()[0];

            // Assert
            Assert.AreEqual(expectedResult, this.testCollection.Print(), "Printed element does not match expected element!");
        }

        [Test]
        public void CannotPrintElementFromCollection()
        {
            // Arrange
            this.testCollection = new ListyIterator<string>();

            // Assert
            Assert.Throws<EmptyCollectionException>(() => this.testCollection.Print(),
                "Cannot print element from empty collection.");
        }

        private void SetInternalIndex(int size = DefaultTestSize - 1)
        {
            if (size >= DefaultTestSize)
            {
                size = DefaultTestSize - 1;
            }

            this.testCollection.GetType()
                .GetField("internalIndex", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(this.testCollection, (object)(size));
        }

        private int GetInternalIndex()
        {
            return (int)this.testCollection.GetType()
                .GetField("internalIndex", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(this.testCollection);
        }

        private string[] GetInternalCollection()
        {
            return (string[])this.testCollection.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(n => n.Name == "data")
                .GetValue(this.testCollection);
        }

        private string[] TestArrayGenerator()
        {
            string[] testArray = new string[DefaultTestSize];

            for (int i = 0; i < testArray.Length; i++)
            {
                testArray[i] = (i + 1).ToString();
            }

            return testArray;
        }
    }
}