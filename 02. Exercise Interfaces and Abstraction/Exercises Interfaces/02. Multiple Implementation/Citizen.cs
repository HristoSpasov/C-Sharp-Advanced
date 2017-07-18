using _02.Multiple_Implementation.Interfaces;

namespace _02.Multiple_Implementation
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthday { get; set; }
        public string Id { get; set; }
    }
}