using _05.Border_Control.Entities;
using _05.Border_Control.Interfaces;

namespace _05.Border_Control.Factories
{
    public static class SocietyMemberFactory
    {
        public static IDable GetMember(string[] args)
        {
            int argsCount = args.Length;

            switch (argsCount)
            {
                case 2:
                    return new Robot(args[1], args[0]);

                case 3:
                default:
                    return new Citizen(args[2], args[0], int.Parse(args[1]));
            }
        }
    }
}