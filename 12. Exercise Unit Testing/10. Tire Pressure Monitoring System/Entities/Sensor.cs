using System;

namespace _10.Tire_Pressure_Monitoring_System.Entities
{
    public class Sensor
    {
        //
        // The reading of the pressure value from the sensor is simulated in this implementation.
        // Because the focus of the exercise is on the other class.
        //

        private const double Offset = 16;
        private readonly Random randomPressureSampleSimulator = new Random();

        public double PopNextPressurePsiValue()
        {
            double pressureTelemetryValue = this.ReadPressureSample();

            return Offset + pressureTelemetryValue;
        }

        private double ReadPressureSample()
        {
            // Simulate info read from a real sensor in a real tire
            return 6 * this.randomPressureSampleSimulator.NextDouble() * this.randomPressureSampleSimulator.NextDouble();
        }
    }
}