using _08.Custom_List.IO.Commands;
using System.Collections.Generic;

namespace _08.Custom_List.Factories
{
    public static class CommandFactory
    {
        public static Command GetCommand(List<string> args, GenericList<string> list)
        {
            string command = args[0];
            args.RemoveAt(0);

            switch (command)
            {
                case "Add":
                    return new Add(list, args);

                case "Remove":
                    return new Remove(list, args);

                case "Contains":
                    return new Contains(list, args);

                case "Swap":
                    return new Swap(list, args);

                case "Greater":
                    return new Greater(list, args);

                case "Max":
                    return new Max(list, args);

                case "Min":
                    return new Min(list, args);

                case "Print":
                    return new Print(list, args);

                default:
                    return null;
            }
        }
    }
}