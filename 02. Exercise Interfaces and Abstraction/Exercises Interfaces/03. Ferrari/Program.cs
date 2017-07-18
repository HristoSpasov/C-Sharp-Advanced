using System;

namespace _03.Ferrari
{
    public class Program
    {
        public static void Main()
        {
            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }

            string driverName = Console.ReadLine();

            ICar someCar = new Ferrari(driverName);

            Console.WriteLine(someCar.ToString());
        }
    }
}