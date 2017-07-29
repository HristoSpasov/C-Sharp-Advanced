using _11.Inferno_Infinity.Entities.Interfaces;
using _11.Inferno_Infinity.Enums;
using _11.Inferno_Infinity.Utilities;
using System;
using System.Linq;

namespace _11.Inferno_Infinity.Entities.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int minDamage;
        private int maxDamage;
        private int sockets;
        private string type;
        private string rarityType;
        private IGem[] gems;
        private int bonusMinDamage;
        private int bonusMaxDamage;

        protected Weapon(string rarityType, string type, string name)
        {
            this.RarityType = rarityType;
            this.Type = type;
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public string RarityType
        {
            get { return this.rarityType; }
            private set { this.rarityType = value; }
        }

        public string Type
        {
            get { return this.type; }
            private set { this.type = value; }
        }

        public int MinDamage
        {
            get { return this.minDamage; }
            protected set { this.minDamage = value; }
        }

        public int MaxDamage
        {
            get { return this.maxDamage; }
            protected set { this.maxDamage = value; }
        }

        public int Sockets
        {
            get { return this.sockets; }
            protected set { this.sockets = value; }
        }

        public IGem[] Gems
        {
            get { return this.gems; }
            protected set { this.gems = value; }
        }

        public int BonusMinDamage
        {
            get { return this.bonusMinDamage; }
            private set { this.bonusMinDamage = value; }
        }

        public int BonusMaxDamage
        {
            get { return this.bonusMaxDamage; }
            private set { this.bonusMaxDamage = value; }
        }

        protected void IncreaseWeaponDamageAccordingToType()
        {
            RarityType rarityType = (RarityType)Enum.Parse(typeof(RarityType), this.RarityType);

            this.MinDamage *= (int)rarityType;
            this.MaxDamage *= (int)rarityType;
        }

        public void AddGem(int targetIndex, IGem gem)
        {
            if (TargetIndexIsValid(targetIndex))
            {
                this.Gems[targetIndex] = gem;
                this.CalculateDamageBonus();
            }
        }

        public void RemoveGem(int targetSocket)
        {
            if (this.TargetIndexIsValid(targetSocket))
            {
                this.Gems[targetSocket] = null;
                this.CalculateDamageBonus();
            }
        }

        public void Print()
        {
            OutputConsoleWriter.AddReportLine(this.ToString());
        }

        public override string ToString()
        {
            return
                $"{this.Name}: {this.MinDamage + this.BonusMinDamage}-{this.MaxDamage + this.BonusMaxDamage} Damage," +
                $" +{this.Gems.Where(g => g != null).Select(g => g.Strength).Sum()} Strength," +
                $" +{this.Gems.Where(g => g != null).Select(g => g.Agility).Sum()} Agility," +
                $" +{this.Gems.Where(g => g != null).Select(g => g.Vitality).Sum()} Vitality";
        }

        private void CalculateDamageBonus()
        {
            int totalStrengthPoints = this.Gems.Where(g => g != null).Select(s => s.Strength).Sum();
            int totalAgilityPoints = this.Gems.Where(g => g != null).Select(a => a.Agility).Sum();

            this.BonusMinDamage = totalStrengthPoints * 2 + totalAgilityPoints;
            this.BonusMaxDamage = totalStrengthPoints * 3 + totalAgilityPoints * 4;
        }

        private bool TargetIndexIsValid(int targetIndex)
        {
            return targetIndex >= 0 && targetIndex < this.Sockets;
        }
    }
}