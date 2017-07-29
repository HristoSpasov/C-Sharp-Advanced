namespace _10.Create_Custom_Class_Attribute.Entities.Gems
{
    public class Emerald : Gem
    {
        private const int strength = 1;
        private const int agility = 4;
        private const int vitality = 9;

        public Emerald(string levelOfQuality, string type) : base(levelOfQuality, type)
        {
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
            this.IncreaseGemStatsAccordingToGemQuality();
        }
    }
}