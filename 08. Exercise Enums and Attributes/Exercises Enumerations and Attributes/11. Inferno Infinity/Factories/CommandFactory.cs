using _11.Inferno_Infinity.Core;
using _11.Inferno_Infinity.Core.Command;
using System.Linq;

namespace _11.Inferno_Infinity.Factories
{
    public static class CommandFactory
    {
        public static Command GetCommand(Db database, string[] args)
        {
            switch (args[0])
            {
                case "Create":
                    return new CreateCommand(database, args.Skip(1).ToArray());

                case "Add":
                    return new AddCommand(database, args.Skip(1).ToArray());

                case "Remove":
                    return new RemoveCommand(database, args.Skip(1).ToArray());

                case "Print":
                    return new PrintCommand(database, args.Skip(1).ToArray());

                default:
                    return null;
            }
        }
    }
}