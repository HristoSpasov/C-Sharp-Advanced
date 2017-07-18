using _10.Explicit_Interfaces.Entities;
using _10.Explicit_Interfaces.Entities.Interfaces;
using System;

namespace _10.Explicit_Interfaces.Core
{
    public class Engine
    {
        public void Run()
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] args = line.Split();

                IPerson citizen = new Citizen(args[0], args[1], int.Parse(args[2]));
                Console.WriteLine(citizen.GetName());
                IResident citizenResident = new Citizen(args[0], args[1], int.Parse(args[2]));
                Console.WriteLine(citizenResident.GetName());
            }
        }
    }
}