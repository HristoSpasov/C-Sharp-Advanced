using _07.Food_Shortage.Interfaces;

namespace _07.Food_Shortage.Entities
{
    public class Rebel : IBuyer, IRebel
    {
        private const int FoodIncrease = 5;

        public Rebel(string name, string age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.TotalFood = 0;
            this.Group = group;
        }

        public string Name { get; private set; }
        public string Age { get; private set; }
        public int TotalFood { get; private set; }
        public string Group { get; private set; }

        public void BuyFood()
        {
            this.TotalFood += FoodIncrease;
        }
    }
}