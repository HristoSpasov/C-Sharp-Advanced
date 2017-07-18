using _05.Border_Control.Interfaces;
using _06.Birthday_Celebrations.Interfaces;

namespace _05.Border_Control.Entities
{
    public class Citizen : IDable, ICitizen, IBirthable
    {
        public Citizen(string id, string name, int age, string birthday)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Birthday = birthday;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Birthday { get; private set; }
    }
}