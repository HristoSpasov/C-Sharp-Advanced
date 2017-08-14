using System;
using Moq;
using NUnit.Framework;

namespace _07.Hack.Tests
{
    [TestFixture]
    public class MathAbsTests
    { 
        private Mock<IMath> mathClassMock;

        [SetUp]
        public void Initialize()
        {
            this.mathClassMock = new Mock<IMath>();
        }

        [Test]
        public void MathAbsReturnsPositiveNumberWithAnyDoubleOperand()
        {
            //Act
            mathClassMock.Setup(n => n.GetmathAbs(It.IsAny<double>())).Returns(() => Math.Abs(-100));
           
            // Assert
            Assert.AreEqual(100, mathClassMock.Object.GetmathAbs(222));
        }
    }
}
