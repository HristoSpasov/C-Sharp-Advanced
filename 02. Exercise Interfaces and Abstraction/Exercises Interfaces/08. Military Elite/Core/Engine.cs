using _08.Military_Elite.Factories;
using _08.Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Military_Elite.Core
{
    public class Engine
    {
        private bool isRunning;
        private MilitaryEliteManager manager;

        public Engine()
        {
            this.isRunning = true;
            this.manager = new MilitaryEliteManager();
        }

        public void Run()
        {
            while (isRunning)
            {
                List<string> args = Console.ReadLine().Split().ToList();

                if (args[0] == "End")
                {
                    this.isRunning = false;
                    continue;
                }

                ISoldier newUnit = UnitFactory.GetUnit(args, manager);

                if (newUnit != null)
                {
                    manager.AddSoldier(newUnit);
                }
            }

            // Print output
            foreach (var soldier in manager.Soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}