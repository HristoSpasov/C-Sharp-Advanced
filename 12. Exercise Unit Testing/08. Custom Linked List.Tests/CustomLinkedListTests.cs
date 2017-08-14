using NUnit.Framework;

namespace _08.Custom_Linked_List.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class CustomLinkedListTests
    {
        private CustomLinkedList<int> sut;

        [SetUp]
        public void Initialize()
        {
            this.sut = new CustomLinkedList<int>();
        }

        [Test]
        public void TestIfConstructorSetsHeadCorrectly()
        {
            // Act
            FieldInfo[] fieldInfos = this.GetAllFields();

            object headValue = 0;

            foreach (var fieldInfo in fieldInfos)
            {
                if (fieldInfo.Name == "head")
                {
                    headValue = fieldInfo.GetValue(this.sut);
                }
            }

            // Assert
            Assert.AreEqual(null, headValue, "Head value of empty linked list must be null");
        }

        [Test]
        public void TestIfConstructorSetsTailCorrectly()
        {
            // Act
            FieldInfo[] fieldInfos = this.GetAllFields();

            object tailValue = 0;

            foreach (var fieldInfo in fieldInfos)
            {
                if (fieldInfo.Name == "tail")
                {
                    tailValue = fieldInfo.GetValue(this.sut);
                }
            }

            // Assert
            Assert.AreEqual(null, tailValue, "Tail value of empty linked list must be null");
        }

        [Test]
        public void TestIfNewCreatedListHasZeroCountElements()
        {
            // Arrange
            int expectedCount = 0;

            // Act
            int actulaCount = this.sut.Count;

            // Assert
            Assert.AreEqual(expectedCount, actulaCount, "Empty list must have zero count elements!");
        }

        [Test]
        public void TestAddSingleElementInEmptyListCount()
        {
            // Arrange
            int expectedCount = 1;

            // Act
            this.AddElementsToList(1);

            // Assert
            Assert.AreEqual(expectedCount, this.sut.Count, "Adding element to the list does not change list counter size.");
        }

        [Test]
        public void TestIfHeadValueEqualsTailValueAfterAddingSingleElementToEmptyList()
        {
            // Act
            this.AddElementsToList(1);

            // Get head and tail objects value
            object head = this.GetListHeadOrTailObject("head");
            object tail = this.GetListHeadOrTailObject("tail");

            // Get value both in head and tail object
            int elementInHeadValue = this.GetValueFromNode(head);
            int elementInTailValue = this.GetValueFromNode(tail);

            // Assert
            Assert.AreEqual(elementInHeadValue, elementInTailValue, "Value of elements in head and tail in linked list with one element must be equal!");
        }

        [Test]
        public void TestIfHeadNextNodeValueEqualsTailNextNodeValueAfterAddingSingleElementToEmptyList()
        {
            // Act
            this.AddElementsToList(1);

            // Get head and tail objects value
            object head = this.GetListHeadOrTailObject("head");
            object tail = this.GetListHeadOrTailObject("tail");

            // Get value both in head and tail object
            object elementInHeadNextNode = this.GetNextNodeFromNode(head);
            object elementInTailNextNode = this.GetNextNodeFromNode(tail);

            // Assert
            Assert.IsTrue(elementInHeadNextNode == null && elementInTailNextNode == null, "Next node in head and tail in linked list with one element must be null!");
        }

        [Test]
        public void TestIfNextNodeIsSetCorrectlyAfterAddingMoreThanOneElement()
        {
            // Arrange
            this.AddElementsToList(3);

            // Act
            object head = this.GetListHeadOrTailObject("head");
            object secondNode = this.GetNextNodeFromNode(head);
            int secondNodeValue = this.GetValueFromNode(secondNode);

            // Assert
            Assert.AreEqual(2, secondNodeValue, "Adding more than one element in list does not work correctly!");
        }

        [Test]
        public void TestGettingValidElementByIndex()
        {
            // Arrange
            this.AddElementsToList(5);
            int expectedElement = 1;

            // Act
            int actualElement = this.sut[0];

            // Assert
            Assert.AreEqual(expectedElement, actualElement, "Getting existing element by index is not working correctly!");
        }

        [Test]
        public void TestGettingElementWithNegativeIndex()
        {
            // Arrange
            this.AddElementsToList(5);
            string expectedThrownMessage = "Invalid index: -1";

            // Act
            int result = 0;

            // Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => result = this.sut[-1]);
            Assert.AreEqual(expectedThrownMessage, ex.ParamName, "Thrown message is not equal to expected message!");
        }

        [Test]
        public void TestGettingElementWithIndexGreaterThanListElementCount()
        {
            // Arrange
            this.AddElementsToList(5);
            string expectedThrownMessage = "Invalid index: 7";

            // Act
            int result = 0;

            // Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => result = this.sut[7]);
            Assert.AreEqual(expectedThrownMessage, ex.ParamName, "Thrown message is not equal to expected message!");
        }

        [Test]
        public void TestSettingValidElementByIndex()
        {
            // Arrange
            this.AddElementsToList(5);
            int expectedElement = 10;

            // Act
            this.sut[0] = 10;

            // Assert
            Assert.AreEqual(expectedElement, this.sut[0], "Setting existing element by index is not working correctly!");
        }

        [Test]
        public void TestSettingElementWithNegativeIndex()
        {
            // Arrange
            this.AddElementsToList(5);
            string expectedThrownMessage = "Invalid index: -1";

            // Act
            int result = 0;

            // Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => result = this.sut[-1] = 10);
            Assert.AreEqual(expectedThrownMessage, ex.ParamName, "Thrown message is not equal to expected message!");
        }

        [Test]
        public void TestSettingElementWithIndexGreaterThanListElementCount()
        {
            // Arrange
            this.AddElementsToList(5);
            string expectedThrownMessage = "Invalid index: 7";

            // Act
            int result = 0;

            // Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => result = this.sut[7] = 10);
            Assert.AreEqual(expectedThrownMessage, ex.ParamName, "Thrown message is not equal to expected message!");
        }

        [Test]
        public void TestHeadAnTailStatusAfterRemovingElementAtIndexFromListWithOneElement()
        {
            // Arrange
            int indexToRemove = 0;

            // Act
            this.AddElementsToList(1);
            this.sut.RemoveAt(indexToRemove);

            object head = this.GetListHeadOrTailObject("head");
            object tail = this.GetListHeadOrTailObject("tail");

            // Assert
            Assert.IsTrue(head == null && tail == null, "After removing element from list with one element head and tail must be null!");
        }

        [Test]
        public void TestReturnedValueAfterRemovingElementAtIndexFromListWithOneElement()
        {
            // Arrange
            int indexToRemove = 0;
            int expectedReturnValue = 1;

            // Act
            this.AddElementsToList(1);
            int returnedValue = this.sut.RemoveAt(indexToRemove);

            // Assert
            Assert.AreEqual(expectedReturnValue, returnedValue, "Did not return expexted value after useing 'RemoveAt' command.");
        }

        [Test]
        public void TestHeadValueAfterRemovingCurrentHeadNodeFromListWithMoreThanOneElement()
        {
            // Arrange
            int indexToRemove = 0;
            int expectedValueOfHead = 2;

            // Act
            this.AddElementsToList(3);
            this.sut.RemoveAt(indexToRemove);

            object head = this.GetListHeadOrTailObject("head");
            int headValueAfterRemoveAtCommand = this.GetValueFromNode(head);

            // Assert
            Assert.AreEqual(expectedValueOfHead, headValueAfterRemoveAtCommand, "After removing head, new head should be set to next element in list.");
        }

        [Test]
        public void TestTailValueAfterRemovingCurrentTailNodeFromListWithMoreThanOneElement()
        {
            // Arrange
            int indexToRemove = 3;
            int expectedValueOfTail = 3;

            // Act
            this.AddElementsToList(4);
            this.sut.RemoveAt(indexToRemove);

            object tail = this.GetListHeadOrTailObject("tail");
            int tailValueAfterRemoveAtCommand = this.GetValueFromNode(tail);

            // Assert
            Assert.AreEqual(expectedValueOfTail, tailValueAfterRemoveAtCommand, "After removing tail, new tail should be set to previous element in list.");
        }

        [Test]
        public void TestNextNodeRedirectionAfterRemovingElementInTheMiddleOfTheList()
        {
            // Arrange
            int indexTRemoveAt = 2;
            int expectedResultValue = 4;

            // Act
            this.AddElementsToList(5);
            this.sut.RemoveAt(indexTRemoveAt);

            object head = this.GetListHeadOrTailObject("head");
            object second = this.GetNextNodeFromNode(head);
            object third = this.GetNextNodeFromNode(second);
            int thirdValue = this.GetValueFromNode(third);

            // Assert
            Assert.AreEqual(expectedResultValue, thirdValue, "Removing nodes from the middle of the list does not work correctly");
        }

        [Test]
        public void TestRemovingElementAtNegativeIndex()
        {
            // Arrange
            int indexToRemoveAt = -5;
            string expectedMessage = "Invalid index: -5";

            // Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => this.sut.RemoveAt(indexToRemoveAt));
            Assert.AreEqual(expectedMessage, ex.ParamName, "Invalid message thrown!");
        }

        [Test]
        public void TestRemovingElementAtIndexGreaterThanListElements()
        {
            // Arrange
            int indexToRemoveAt = 5;
            string expectedMessage = "Invalid index: 5";

            // Act
            this.AddElementsToList(5);

            // Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => this.sut.RemoveAt(indexToRemoveAt));
            Assert.AreEqual(expectedMessage, ex.ParamName, "Invalid message thrown!");
        }

        [Test]
        public void TestIfCountChangesWhenUsingRemoveItemCommand()
        {
            // Arrange
            this.AddElementsToList(5);
            int expectedCount = 4;

            // Act
            this.sut.Remove(5);

            // Assert
            Assert.AreEqual(expectedCount, this.sut.Count, "Removing elements with Remove item command does not affect elements count!");
        }

        [Test]
        public void TestRemoveFirstElementAtTheBeginingOfTheListMatchingValue()
        {
            // Arrange
            this.AddElementsToList(5);
            int expectedNewHeadValue = 2;

            // Act
            this.sut.Remove(1);
            object head = GetListHeadOrTailObject("head");
            int headValue = this.GetValueFromNode(head);

            // Assert
            Assert.AreEqual(expectedNewHeadValue, headValue, "Removing element at the begining(head) of the list with Remove item command does not work correctly!");
        }

        [Test]
        public void TestRemoveFirstElementAtTheEndOfTheListMatchingValue()
        {
            // Arrange
            this.AddElementsToList(5);
            int expectedNewTailValue = 4;

            // Act
            this.sut.Remove(5);
            object head = GetListHeadOrTailObject("tail");
            int tailValue = this.GetValueFromNode(head);

            // Assert
            Assert.AreEqual(expectedNewTailValue, tailValue, "Removing element at the end(tail) of the list with Remove item command does not work correctly!");
        }

        [Test]
        public void TestRemoveFirstElementInTheMiddleOfTheListMatchingValue()
        {
            // Arrange
            this.AddElementsToList(5);
            int expectedThirdElementInList = 4;

            // Act
            this.sut.Remove(3);
            object head = GetListHeadOrTailObject("head");
            object second = this.GetNextNodeFromNode(head);
            object third = this.GetNextNodeFromNode(second);
            int thirdActualValue = this.GetValueFromNode(third);

            // Assert
            Assert.AreEqual(expectedThirdElementInList, thirdActualValue, "Removing element in the middle of the list with Remove item command does not work correctly!");
        }

        [Test]
        public void TestRemoveFirstElementMatchingRepeatingValueInList()
        {
            // Arrange
            this.AddElementsToList(5);
            this.AddElementsToList(5);
            int expectedHeadValue = 2;

            // Act
            this.sut.Remove(1);
            object head = GetListHeadOrTailObject("head");
            int headValueActual = this.GetValueFromNode(head);

            // Assert
            Assert.AreEqual(expectedHeadValue, headValueActual, "Removing element from list with repeating valuees with Remove item command does not work correctly!");
        }

        [Test]
        public void TestRemoveItemFromEmptyList()
        {
            // Arrange
            int expectedValue = -1;

            // Act
            int actualResult = this.sut.Remove(1);

            // Assert
            Assert.AreEqual(expectedValue, actualResult, "When no number is found the  Remove method must return -1!");
        }

        [Test]
        public void TestRemoveItemFromListContainingElements()
        {
            // Arrange
            this.AddElementsToList(5);
            int expectedValue = -1;

            // Act
            int actualResult = this.sut.Remove(16);

            // Assert
            Assert.AreEqual(expectedValue, actualResult, "When no number is found the  Remove method must return -1!");
        }

        [Test]
        public void TestReturnIndexOfFirstElementInList()
        {
            // Arrange
            this.AddElementsToList(5);
            int expectedIndex = 0;

            // Act
            int actualIndex = this.sut.IndexOf(1);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex, "Index of command does not work correctly!");
        }

        [Test]
        public void TestReturnIndexOfLastElementInList()
        {
            // Arrange
            this.AddElementsToList(5);
            int expectedIndex = this.sut.Count - 1;

            // Act
            int actualIndex = this.sut.IndexOf(5);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex, "Index of command does not work correctly!");
        }

        [Test]
        public void TestReturnIndexOfElementInTheMiddleOfTheList()
        {
            // Arrange
            this.AddElementsToList(5);
            int expectedIndex = 2;

            // Act
            int actualIndex = this.sut.IndexOf(3);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex, "Index of command does not work correctly!");
        }

        [Test]
        public void TestReturnIndexOfElementNotExistingInTheList()
        {
            // Arrange
            this.AddElementsToList(5);
            int expectedIndex = -1;

            // Act
            int actualIndex = this.sut.IndexOf(6);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex, "Index of command does not work correctly! When index is not found the output must be -1.");
        }

        [Test]
        public void TestReturnIndexOfElementInEmptyList()
        {
            // Arrange
            int expectedIndex = -1;

            // Act
            int actualIndex = this.sut.IndexOf(6);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex, "Index of command does not work correctly! When index is not found the output must be -1.");
        }

        [Test]
        public void TestContainsCommandWorkingForExistingValueInList()
        {
            // Arrange
            this.AddElementsToList(5);

            // Assert
            Assert.IsTrue(this.sut.Contains(3), "Returns false for existing element in the list");
        }

        [Test]
        public void TestContainsCommandWorkingForNonExistingValueInList()
        {
            // Arrange
            this.AddElementsToList(5);

            // Assert
            Assert.IsFalse(this.sut.Contains(-3), "Returns true for non existing element in the list");
        }

        private object GetNextNodeFromNode(object node)
        {
            return node
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)[1]
                .GetValue(node);
        }

        private int GetValueFromNode(object node)
        {
            return (int)node
                 .GetType()
                 .GetProperties(BindingFlags.Instance | BindingFlags.Public)[0]
                 .GetValue(node);
        }

        private object GetListHeadOrTailObject(string headOrTail)
        {
            return this.GetAllFields()
                .Where(fn => fn.Name == headOrTail)
                .Select(fval => fval.GetValue(this.sut))
                .First();
        }

        private FieldInfo[] GetAllFields()
        {
            Type myAbstractGenericType = typeof(CustomLinkedList<>);
            Type[] types = { typeof(int) };
            Type constructed = myAbstractGenericType.MakeGenericType(types);

            return constructed.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        }

        private void AddElementsToList(int elementsCountToAdd)
        {
            for (int i = 1; i <= elementsCountToAdd; i++)
            {
                this.sut.Add(i);
            }
        }
    }
}