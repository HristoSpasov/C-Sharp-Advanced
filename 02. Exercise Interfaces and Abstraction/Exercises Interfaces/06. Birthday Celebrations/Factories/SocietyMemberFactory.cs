using _05.Border_Control.Entities;
using _06.Birthday_Celebrations.Entities;
using _06.Birthday_Celebrations.Interfaces;
using System.Linq;

namespace _05.Border_Control.Factories
{
    public static class SocietyMemberFactory
    {
        public static IBirthable GetMember(string[] args)
        {
            if (args.Last().Contains("/"))
            {
                string type = args[0];

                switch (type)
                {
                    case "Citizen":
                        return new Citizen(args[3], args[1], int.Parse(args[2]), args[4]);

                    case "Pet":
                    default:
                        return new Pet(args[1], args[2]);
                }
            }

            return null;
        }
    }
}