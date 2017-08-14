using System;
using _01.EventImplementation.Entities;

namespace _01.EventImplementation
{
    public class Program
    {
        public static void Main()
        {
            Dispatcher dispatcher = new Dispatcher();
            NameChanged nameChanged = new NameChanged();
            dispatcher.NameChange += nameChanged.OnNameChanged;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                dispatcher.Name = line;
            }
        }
    }
}