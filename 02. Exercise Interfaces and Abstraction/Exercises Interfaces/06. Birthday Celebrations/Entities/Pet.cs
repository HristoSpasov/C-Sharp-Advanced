using _06.Birthday_Celebrations.Interfaces;

namespace _06.Birthday_Celebrations.Entities
{
    public class Pet : IBirthable, IPet
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; private set; }
        public string Birthday { get; private set; }
    }
}