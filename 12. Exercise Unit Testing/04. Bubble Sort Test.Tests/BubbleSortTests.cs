using NUnit.Framework;
using System;
using System.Reflection;

namespace _04.Bubble_Sort_Test.Tests
{
    [TestFixture]
    public class BubbleSortTests
    {
        private BubbleSort<int> testCollection;

        [SetUp]
        public void InitializeData()
        {
            this.testCollection = new BubbleSort<int>(this.GenerateCollection());
        }

        [Test]
        public void TestConstructorWithSomeElements()
        {
            // Arrange
            int expectedCount = this.GenerateCollection().Length;

            // Act
            int[] internalCollection = this.GetInternalCollection();
            int internalCollectionLength = internalCollection.Length;

            // Assert
            Assert.AreEqual(expectedCount, internalCollectionLength, "The length of the internal collection is not the sama as the length of test collection");
        }

        [Test]
        public void TestConstructorWithNullParameter()
        {
            // Assert
            NullReferenceException ex = Assert.Throws<NullReferenceException>(() => new BubbleSort<int>(null), "Constructor parameter should be null!");
            Assert.AreEqual("Cannot make BubbleSort instance with null collection!", ex.Message, "Expexted exception is invalid.");
        }

        [Test]
        public void SortCollection()
        {
            // Arrange
            int[] expected = new[] { 1, 4, 5, 5, 94 };

            // Act
            int[] sorted = this.testCollection.Sort();

            // Assert
            CollectionAssert.AreEqual(expected, sorted, "The collection is not sorted correctly");
        }

        private int[] GetInternalCollection()
        {
            return (int[])this.testCollection
                .GetType()
                .GetField("collection", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(this.testCollection);
        }

        private int[] GenerateCollection()
        {
            return new[] { 5, 4, 5, 94, 1 };
        }
    }
}