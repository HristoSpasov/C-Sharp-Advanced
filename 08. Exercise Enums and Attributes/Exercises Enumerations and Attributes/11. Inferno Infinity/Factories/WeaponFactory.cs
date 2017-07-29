using _11.Inferno_Infinity.Entities.Interfaces;
using _11.Inferno_Infinity.Entities.Weapons;

namespace _11.Inferno_Infinity.Factories
{
    public static class WeaponFactory
    {
        public static IWeapon GetWeapon(string name, string rarityType, string type)
        {
            switch (type)
            {
                case "Axe":
                    return new Axe(rarityType, type, name);

                case "Sword":
                    return new Sword(rarityType, type, name);

                case "Knife":
                    return new Knife(rarityType, type, name);

                default:
                    return null;
            }
        }
    }
}