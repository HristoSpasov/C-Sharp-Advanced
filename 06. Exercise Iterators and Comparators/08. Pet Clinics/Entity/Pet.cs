using _08.Pet_Clinics.Entity.Interfaces;

namespace _08.Pet_Clinics.Entity
{
    public class Pet : IPet
    {
        private string name;
        private int age;
        private string kind;

        public Pet(string name, int age, string kind)
        {
            this.Name = name;
            this.Age = age;
            this.Kind = kind;
        }

        public string Name
        {
            get { return name; }
            private set { this.name = value; }
        }

        public int Age
        {
            get { return age; }
            private set { this.age = value; }
        }

        public string Kind
        {
            get { return kind; }
            private set { this.kind = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Kind}";
        }
    }
}