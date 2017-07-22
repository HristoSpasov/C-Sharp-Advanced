using System.Collections.Generic;
using _10.Custom_List_Iterator.Generic;

namespace _10.Custom_List_Iterator.IO.Commands
{
    public class Add : Command
    {
        public Add(GenericList<string> list, List<string> args) : base(list, args)
        {
        }

        public override void Execute()
        {
            this.List.Add(this.Args[0]);
        }
    }
}