using _07.Food_Shortage.Interfaces;

namespace _07.Food_Shortage.Entities
{
    public class Citizen : IBuyer, ICitizen
    {
        private const int FoodIncrease = 10;

        public Citizen(string name, string age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.TotalFood = 0;
            this.Id = id;
            this.Birthday = birthday;
        }

        public string Name { get; private set; }
        public string Age { get; private set; }
        public int TotalFood { get; private set; }
        public string Id { get; private set; }
        public string Birthday { get; private set; }

        public void BuyFood()
        {
            this.TotalFood += FoodIncrease;
        }
    }
}