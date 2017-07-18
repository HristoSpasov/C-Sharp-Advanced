namespace _03.Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string drivernName)
        {
            this.DriverName = drivernName;
            this.Model = "488-Spider";
        }

        public string Model { get; private set; }

        public string DriverName { get; private set; }

        public string Brake()
        {
            return "Brakes!";
        }

        public string PedalToTheMetal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brake()}/{this.PedalToTheMetal()}/{this.DriverName}";
        }
    }
}