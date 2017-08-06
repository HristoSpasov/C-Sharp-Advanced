using System;
using NUnit.Framework;

[TestFixture()]
public class AxeTests
{
    private const int DefaultDummyHealth = 10;
    private const int DefaultDummyExperience = 10;

    private ITarget dummy;

    [SetUp]
    public void InitializeData()
    {
        this.dummy = new Dummy(DefaultDummyHealth, DefaultDummyExperience);
    }

    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        int axeAttack = 10;
        int axeDurability = 10;

        // Arrange
        IWeapon axe = new Axe(axeAttack, axeDurability);

        // Act
        axe.Attack(this.dummy);

        // Assert
        Assert.AreEqual(9, axe.DurabilityPoints, "Axe Durability doesnt change after attack");
    }

    [Test]
    public void AttackWithBrokenWeapon()
    {
        int axeAttack = 1;
        int axeDurability = 1;

        // Arrange
        Axe axe = new Axe(axeAttack, axeDurability);

        // Act
        axe.Attack(this.dummy);

        // Assert
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(this.dummy));
        Assert.AreEqual("Axe is broken.", ex.Message, "Wrong exception message.");
    }
}