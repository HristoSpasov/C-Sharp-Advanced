using _10.Create_Custom_Class_Attribute.Entities.Gems;
using _10.Create_Custom_Class_Attribute.Entities.Interfaces;

namespace _10.Create_Custom_Class_Attribute.Factories
{
    public static class GemFactory
    {
        public static IGem GetGem(string gemType, string gemQuality)
        {
            switch (gemType)
            {
                case "Ruby":
                    return new Ruby(gemQuality, gemType);

                case "Emerald":
                    return new Emerald(gemQuality, gemType);

                case "Amethyst":
                    return new Amethyst(gemQuality, gemType);

                default:
                    return null;
            }
        }
    }
}