using _07.Food_Shortage.Entities;
using _07.Food_Shortage.Interfaces;

namespace _07.Food_Shortage.Factories
{
    public static class IBuyerFactory
    {
        public static IBuyer GetIBuyer(string[] args)
        {
            int argsCount = args.Length;

            switch (argsCount)
            {
                case 4:
                    return new Citizen(args[0], args[1], args[2], args[3]);

                case 3:
                default:
                    return new Rebel(args[0], args[1], args[2]);
            }
        }
    }
}