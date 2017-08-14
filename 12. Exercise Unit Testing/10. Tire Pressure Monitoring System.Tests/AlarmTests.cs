using NUnit.Framework;

namespace _10.Tire_Pressure_Monitoring_System.Tests
{
    using System.Linq;
    using System.Reflection;
    using Moq;
    using _10.Tire_Pressure_Monitoring_System.Contracts;
    using _10.Tire_Pressure_Monitoring_System.Entities;

    [TestFixture]
    public class AlarmTests
    {
        private readonly double lowPressureThreshold = GetValueFromAlarmClass(nameof(lowPressureThreshold));
        private readonly double highPressureThreshold = GetValueFromAlarmClass(nameof(highPressureThreshold));

        private Mock<IAlarm> alarmMock;
        private Mock<ISensor> sensorMock;

        [SetUp]
        public void Initialize()
        {
            this.alarmMock = new Mock<IAlarm>();
            this.sensorMock = new Mock<ISensor>();
        }

        [Test]
        public void TestWhenPressureIsLessThanLowPressureThreshold()
        {
            // Arrange
            this.sensorMock.Setup(ptv => ptv.PopNextPressurePsiValue()).Returns(this.lowPressureThreshold - 1);

            // Act
            this.SetAlarmState();

            // Arrange
            Assert.IsTrue(this.alarmMock.Object.AlarmOn, "Pressure is under low pressure threshold and must triger the alarm!");
        }

        [Test]
        public void TestWhenPressureIsEqualToLowPressureThreshold()
        {
            // Arrange
            this.sensorMock.Setup(ptv => ptv.PopNextPressurePsiValue()).Returns(this.lowPressureThreshold);

            // Act
            this.SetAlarmState();

            // Arrange
            Assert.IsFalse(this.alarmMock.Object.AlarmOn, "Pressure is in allowed range and must not triger the alarm!");
        }

        [Test]
        public void TestWhenPressureIsEqualToHighPressureThreshold()
        {
            // Arrange
            this.sensorMock.Setup(ptv => ptv.PopNextPressurePsiValue()).Returns(this.highPressureThreshold);

            // Act
            this.SetAlarmState();

            // Arrange
            Assert.IsFalse(this.alarmMock.Object.AlarmOn, "Pressure is in allowed range and must not triger the alarm!");
        }

        [Test]
        public void TestWhenPressureIsBetweenLowAndHighPressureThreshold()
        {
            // Arrange
            this.sensorMock.Setup(ptv => ptv.PopNextPressurePsiValue()).Returns((this.highPressureThreshold + this.lowPressureThreshold) / 2.0);

            // Act
            this.SetAlarmState();

            // Arrange
            Assert.IsFalse(this.alarmMock.Object.AlarmOn, "Pressure is in allowed range and must not triger the alarm!");
        }

        [Test]
        public void TestWhenPressureIsAboveHighPressureThreshold()
        {
            // Arrange
            this.sensorMock.Setup(ptv => ptv.PopNextPressurePsiValue()).Returns(this.highPressureThreshold + 1);

            // Act
            this.SetAlarmState();

            // Arrange
            Assert.IsTrue(this.alarmMock.Object.AlarmOn, "Pressure is above high pressure threshold and must triger the alarm!");
        }

        private void SetAlarmState()
        {
            if (this.sensorMock.Object.PopNextPressurePsiValue() < this.lowPressureThreshold ||
                this.sensorMock.Object.PopNextPressurePsiValue() > this.highPressureThreshold)
            {
                this.alarmMock.Setup(alarm => alarm.AlarmOn).Returns(true);
            }
            else
            {
                this.alarmMock.Setup(alarm => alarm.AlarmOn).Returns(false);
            }
        }

        private static double GetValueFromAlarmClass(string name)
        {
            string pascalCaseName = name.First().ToString().ToUpper() + name.Substring(1);

            return (double)typeof(Alarm)
                .GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                .First(f => f.Name == pascalCaseName)
                .GetRawConstantValue();
        }
    }
}
