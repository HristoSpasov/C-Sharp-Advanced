using _07.Food_Shortage.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _07.Food_Shortage.Core
{
    public class FoodManager
    {
        private List<IBuyer> buyers;

        public FoodManager()
        {
            this.buyers = new List<IBuyer>();
        }

        public void AddBuyer(IBuyer newBuyer)
        {
            this.buyers.Add(newBuyer);
        }

        public int GetTotalFood()
        {
            return this.buyers.Select(f => f.TotalFood).Sum();
        }

        public IBuyer GetBuyer(string name)
        {
            return this.buyers.FirstOrDefault(n => n.Name == name);
        }
    }
}