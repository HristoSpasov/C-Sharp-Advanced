using System.Collections.Generic;

namespace _08.Custom_List.IO.Commands
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