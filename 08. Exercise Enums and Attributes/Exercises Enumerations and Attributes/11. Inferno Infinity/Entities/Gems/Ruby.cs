namespace _11.Inferno_Infinity.Entities.Gems
{
    public class Ruby : Gem
    {
        private const int strength = 7;
        private const int agility = 2;
        private const int vitality = 5;

        public Ruby(string levelOfQuality, string type) : base(levelOfQuality, type)
        {
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
            this.IncreaseGemStatsAccordingToGemQuality();
        }
    }
}