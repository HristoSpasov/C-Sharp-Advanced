using _04.Telephony.Models;
using System;

namespace _04.Telephony
{
    public class Program
    {
        public static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] webSites = Console.ReadLine().Split();

            Smartphone smart = new Smartphone();

            foreach (var number in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(smart.Call(number));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var site in webSites)
            {
                try
                {
                    Console.WriteLine(smart.Browse(site));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}