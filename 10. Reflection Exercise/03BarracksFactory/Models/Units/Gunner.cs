namespace _05.BarracksFactory_DI.Models.Units
{
    public class Gunner : Unit
    {
        private const int DefaultHealth = 20;
        private const int DefaultDamage = 20;

        public Gunner() : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}