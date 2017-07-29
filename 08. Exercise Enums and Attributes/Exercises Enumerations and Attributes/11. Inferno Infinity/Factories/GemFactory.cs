using _11.Inferno_Infinity.Entities.Gems;
using _11.Inferno_Infinity.Entities.Interfaces;

namespace _11.Inferno_Infinity.Factories
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