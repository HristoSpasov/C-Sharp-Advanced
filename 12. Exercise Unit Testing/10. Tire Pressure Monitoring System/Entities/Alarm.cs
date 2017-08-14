namespace _10.Tire_Pressure_Monitoring_System.Entities
{
    using _10.Tire_Pressure_Monitoring_System.Contracts;

    public class Alarm : IAlarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private readonly Sensor sensor = new Sensor();

        private bool alarmOn = false;

        public void Check()
        {
            double psiPressureValue = this.sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                this.alarmOn = true;
            }
        }

        public bool AlarmOn
        {
            get { return this.alarmOn; }
        }
    }
}