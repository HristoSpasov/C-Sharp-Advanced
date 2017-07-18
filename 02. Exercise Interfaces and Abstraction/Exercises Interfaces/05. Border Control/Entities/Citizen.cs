using _05.Border_Control.Interfaces;

namespace _05.Border_Control.Entities
{
    public class Citizen : IDable, ICitizen
    {
        public Citizen(string id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
    }
}