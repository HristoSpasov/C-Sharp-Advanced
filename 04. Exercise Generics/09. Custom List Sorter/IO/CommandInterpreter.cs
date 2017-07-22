using _09.Custom_List_Sorter.Factories;
using _09.Custom_List_Sorter.IO.Commands;
using System.Collections.Generic;
using _09.Custom_List_Sorter.Generic;

namespace _09.Custom_List_Sorter.IO
{
    public class CommandInterpreter
    {
        public void InterpreteCommand(List<string> args, GenericList<string> list)
        {
            Command newCommand = CommandFactory.GetCommand(args, list);
            newCommand.Execute();
        }
    }
}