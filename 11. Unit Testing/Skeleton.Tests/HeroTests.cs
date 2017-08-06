using Moq;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture()]
    public class HeroTests
    {
        private const int DefaultExperienceToReturn = 10;

        [Test]
        public void HumanGainsXpWhenTargetDies()
        {
            // Arrange
            Mock<IWeapon> weapon = new Mock<IWeapon>();
            IHero hero = new Hero("Ivan", weapon.Object);
            Mock<ITarget> dummyMock = new Mock<ITarget>();
            dummyMock.Setup(x => x.IsDead()).Returns(true);
            dummyMock.Setup(de => de.GiveExperience()).Returns(DefaultExperienceToReturn);

            // Act
            hero.Attack(dummyMock.Object);

            // Assert
            Assert.AreEqual(10, hero.Experience);
        }
    }
}