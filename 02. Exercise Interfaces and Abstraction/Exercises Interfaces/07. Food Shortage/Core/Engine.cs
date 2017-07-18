using _07.Food_Shortage.Factories;
using _07.Food_Shortage.Interfaces;
using System;

namespace _07.Food_Shortage.Core
{
    public class Engine
    {
        private bool isRunning;
        private FoodManager manager;

        public Engine()
        {
            this.isRunning = true;
            this.manager = new FoodManager();
        }

        public void Run()
        {
            this.ReadAllBuyers(); // Read all buyers

            this.StartShopping(); // Shop while end command is received

            this.PrintTotalFoodBought(); // Print all food bought
        }

        private void PrintTotalFoodBought()
        {
            Console.WriteLine(manager.GetTotalFood());
        }

        private void StartShopping()
        {
            while (this.isRunning)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    this.isRunning = false;
                    continue;
                }

                IBuyer newBuyer = manager.GetBuyer(line);

                newBuyer?.BuyFood(); // Buy food only for existing buyers
            }
        }

        private void ReadAllBuyers()
        {
            int buyersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < buyersCount; i++)
            {
                this.manager.AddBuyer(IBuyerFactory.GetIBuyer(Console.ReadLine().Split()));
            }
        }
    }
}