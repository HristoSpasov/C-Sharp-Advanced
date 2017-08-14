using System;
using Moq;
using NUnit.Framework;

namespace _07.Hack.Tests
{
    [TestFixture]
    public class MathFloorTests
    {
        private Mock<IMath> mathClassMock;

        [SetUp]
        public void Initialize()
        {
            this.mathClassMock = new Mock<IMath>();
        }

        [Test]
        public void TestMathFloorWithAnyDoubleNegativeNumber()
        {
            // Act
            mathClassMock.Setup(m => m.GetMathFloor(It.IsInRange(double.MinValue, 0.0, Range.Exclusive))).Returns(() => Math.Floor(-1.5));

            // Assert
            Assert.AreEqual(-2, mathClassMock.Object.GetMathFloor(-20322323.3333));
        }

        [Test]
        public void TestMathFloorWithAnyDoublPositiveNumber()
        {
            // Act
            mathClassMock.Setup(m => m.GetMathFloor(It.IsInRange(0.0, double.MaxValue, Range.Inclusive))).Returns(() => Math.Floor(2.5));

            // Assert
            Assert.AreEqual(2, mathClassMock.Object.GetMathFloor(20322323.3333));
        }
    }
}
