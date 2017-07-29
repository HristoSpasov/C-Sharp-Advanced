using _10.Create_Custom_Class_Attribute.Entities.Interfaces;
using _10.Create_Custom_Class_Attribute.Enums;
using System;

namespace _10.Create_Custom_Class_Attribute.Entities.Gems
{
    public abstract class Gem : IGem
    {
        private int strength;
        private int agility;
        private int vitality;
        private string levelOfQuality;
        private string type;

        protected Gem(string levelOfQuality, string type)
        {
            this.LevelOfQuality = levelOfQuality;
            this.Type = type;
        }

        public string LevelOfQuality
        {
            get { return this.levelOfQuality; }
            protected set { this.levelOfQuality = value; }
        }

        public string Type
        {
            get { return this.type; }
            private set { this.type = value; }
        }

        public int Strength
        {
            get { return this.strength; }
            protected set { this.strength = value; }
        }

        public int Agility
        {
            get { return this.agility; }
            protected set { this.agility = value; }
        }

        public int Vitality
        {
            get { return this.vitality; }
            protected set { this.vitality = value; }
        }

        protected void IncreaseGemStatsAccordingToGemQuality()
        {
            LevelOfQuality quality = (LevelOfQuality)Enum.Parse(typeof(LevelOfQuality), this.LevelOfQuality);
            this.Strength += (int)quality;
            this.Agility += (int)quality;
            this.Vitality += (int)quality;
        }
    }
}