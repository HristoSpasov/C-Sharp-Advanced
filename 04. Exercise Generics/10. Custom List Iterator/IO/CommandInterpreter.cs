using _10.Custom_List_Iterator.Factories;
using _10.Custom_List_Iterator.IO.Commands;
using System.Collections.Generic;
using _10.Custom_List_Iterator.Generic;

namespace _10.Custom_List_Iterator.IO
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