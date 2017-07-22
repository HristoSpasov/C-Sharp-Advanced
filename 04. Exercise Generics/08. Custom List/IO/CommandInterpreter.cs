using _08.Custom_List.Factories;
using _08.Custom_List.IO.Commands;
using System.Collections.Generic;

namespace _08.Custom_List.IO
{
    public class CommandInterpreter
    {
        public void InterpreteCommand(List<string> args, GenericList<string> list)
        {
            Command newCommand = CommandFactory.GetCommand(args, list);
            newCommand?.Execute();
        }
    }
}