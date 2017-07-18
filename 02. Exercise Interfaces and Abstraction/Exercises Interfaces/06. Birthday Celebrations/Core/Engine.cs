using _05.Border_Control.Core;
using _05.Border_Control.Factories;
using _06.Birthday_Celebrations.Interfaces;
using System;

namespace _06.Birthday_Celebrations.Core
{
    public class Engine
    {
        private bool isRunning;
        private SocietyManager manager;

        public Engine()
        {
            this.isRunning = true;
            this.manager = new SocietyManager();
        }

        public void Run()
        {
            while (this.isRunning)
            {
                string[] lineArgs = Console.ReadLine().Split();

                if (lineArgs[0] == "End")
                {
                    this.isRunning = false;
                    continue;
                }

                IBirthable newMember = SocietyMemberFactory.GetMember(lineArgs);

                if (newMember != null)
                {
                    manager.AddMember(newMember);
                }
            }

            // Get all members with birth year
            string birthYear = Console.ReadLine();

            // Print result
            Console.WriteLine(manager.GetMembersWithBirthYear(birthYear).Trim());
        }
    }
}