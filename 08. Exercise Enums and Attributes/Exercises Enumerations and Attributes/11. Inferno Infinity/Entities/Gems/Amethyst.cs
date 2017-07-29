namespace _11.Inferno_Infinity.Entities.Gems
{
    public class Amethyst : Gem
    {
        private const int strength = 2;
        private const int agility = 8;
        private const int vitality = 4;

        public Amethyst(string levelOfQuality, string type) : base(levelOfQuality, type)
        {
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
            this.IncreaseGemStatsAccordingToGemQuality();
        }
    }
}