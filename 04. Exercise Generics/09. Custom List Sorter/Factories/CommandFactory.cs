﻿using _09.Custom_List_Sorter.IO.Commands;
using System.Collections.Generic;
using _09.Custom_List_Sorter.Generic;

namespace _09.Custom_List_Sorter.Factories
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
                case "Sort":
                    return new Sort(list, args);
                case "Print":
                default:
                    return new Print(list, args);
            }
        }
    }
}