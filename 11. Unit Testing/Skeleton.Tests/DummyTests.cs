using System;
using NUnit.Framework;

[TestFixture()]
public class DummyTests
{
    private const int DummyDefaultHealth = 10;
    private const int DummyDefaultExperience = 10;

    private ITarget dummy;
    private IWeapon axe;

    [SetUp]
    public void InitializeData()
    {
        this.dummy = new Dummy(DummyDefaultHealth, DummyDefaultExperience);
    }

    [Test]
    public void DummyLoosesHealthIfAttacked()
    {
        int testAttackPower = 2;
        int testDurability = 2;

        // Arrange
        this.axe = new Axe(testAttackPower, testDurability);

        // Act
        this.axe.Attack(this.dummy);

        // Assert
        Assert.AreEqual(8, this.dummy.Health, "Dummy does not loose health after being attacked");
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        // Act
        this.dummy.TakeAttack(10);

        // Assert
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1));
        Assert.AreEqual("Dummy is dead.", ex.Message, "Exception message is not correct");
    }

    [Test]
    public void DeadDummyCanGiveXp()
    {
        int testAttackPower = 10;
        int testDurability = 10;

        // Arrange
        this.axe = new Axe(testAttackPower, testDurability);

        // Act
        this.axe.Attack(this.dummy);

        // Assert
        Assert.AreEqual(10, this.dummy.GiveExperience(), "Dummy is not dead.");
    }

    [Test]
    public void AliveDummyCanNotGiveXp()
    {
        int testAttackPower = 3;
        int testDurability = 3;

        // Arrange
        this.axe = new Axe(testAttackPower, testDurability);

        // Act
        this.axe.Attack(this.dummy);

        // Assert
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
        Assert.AreEqual("Target is not dead.", ex.Message, "Dummy is still alive");
    }
}