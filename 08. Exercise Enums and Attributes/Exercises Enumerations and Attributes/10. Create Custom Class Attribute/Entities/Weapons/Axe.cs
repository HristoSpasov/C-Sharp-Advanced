using _10.Create_Custom_Class_Attribute.Entities.Interfaces;

namespace _10.Create_Custom_Class_Attribute.Entities.Weapons
{
    public class Axe : Weapon
    {
        private const int baseMinDamage = 5;
        private const int baseMaxDamage = 10;
        private const int sockets = 4;

        public Axe(string rarityType, string type, string name) : base(rarityType, type, name)
        {
            this.MinDamage = baseMinDamage;
            this.MaxDamage = baseMaxDamage;
            this.Sockets = sockets;
            this.Gems = new IGem[sockets];
            this.IncreaseWeaponDamageAccordingToType();
        }
    }
}