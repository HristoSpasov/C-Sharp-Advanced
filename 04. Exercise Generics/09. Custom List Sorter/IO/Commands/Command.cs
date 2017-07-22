using System.Collections.Generic;
using _09.Custom_List_Sorter.Generic;

namespace _09.Custom_List_Sorter.IO.Commands
{
    public abstract class Command
    {
        private readonly GenericList<string> list;
        private readonly List<string> args;

        protected Command(GenericList<string> list, List<string> args)
        {
            this.list = list;
            this.args = args;
        }

        protected GenericList<string> List => this.list;

        protected List<string> Args => this.args;

        public abstract void Execute();
    }
}