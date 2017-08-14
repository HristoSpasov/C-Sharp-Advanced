namespace _10.Tire_Pressure_Monitoring_System
{
    using System;
    using _10.Tire_Pressure_Monitoring_System.Contracts;
    using _10.Tire_Pressure_Monitoring_System.Entities;

    public class Program
    {
        public static void Main()
        {
            IAlarm alarm = new Alarm();
            alarm.Check();
            Console.WriteLine(alarm.AlarmOn);
        }
    }
}