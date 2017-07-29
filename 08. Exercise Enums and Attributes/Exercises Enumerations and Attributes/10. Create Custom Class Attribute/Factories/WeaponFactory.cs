using _10.Create_Custom_Class_Attribute.Entities.Interfaces;
using _10.Create_Custom_Class_Attribute.Entities.Weapons;

namespace _10.Create_Custom_Class_Attribute.Factories
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