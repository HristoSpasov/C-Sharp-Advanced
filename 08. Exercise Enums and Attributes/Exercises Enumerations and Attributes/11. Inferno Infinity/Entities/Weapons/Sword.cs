﻿using _11.Inferno_Infinity.Entities.Interfaces;

namespace _11.Inferno_Infinity.Entities.Weapons
{
    public class Sword : Weapon
    {
        private const int baseMinDamage = 4;
        private const int baseMaxDamage = 6;
        private const int sockets = 3;

        public Sword(string rarityType, string type, string name) : base(rarityType, type, name)
        {
            this.MinDamage = baseMinDamage;
            this.MaxDamage = baseMaxDamage;
            this.Sockets = sockets;
            this.Gems = new IGem[sockets];
            this.IncreaseWeaponDamageAccordingToType();
        }
    }
}