using _05.Border_Control.Factories;
using _05.Border_Control.Interfaces;
using System;

namespace _05.Border_Control.Core
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

                IDable newMember = SocietyMemberFactory.GetMember(lineArgs);

                manager.AddMember(newMember);
            }

            // Get all members with ID -ending with
            string endindWithString = Console.ReadLine();

            // Print result
            Console.WriteLine(manager.GetMembersWithIdEndingWith(endindWithString));
        }
    }
}