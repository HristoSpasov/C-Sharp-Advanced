using _11.Inferno_Infinity.Entities.Interfaces;

namespace _11.Inferno_Infinity.Entities.Weapons
{
    public class Knife : Weapon
    {
        private const int baseMinDamage = 3;
        private const int baseMaxDamage = 4;
        private const int sockets = 2;

        public Knife(string rarityType, string type, string name) : base(rarityType, type, name)
        {
            this.MinDamage = baseMinDamage;
            this.MaxDamage = baseMaxDamage;
            this.Sockets = sockets;
            this.Gems = new IGem[sockets];
            this.IncreaseWeaponDamageAccordingToType();
        }
    }
}