using System.Collections.Generic;

namespace _08.Custom_List.IO.Commands
{
    public class Swap : Command
    {
        public Swap(GenericList<string> list, List<string> args) : base(list, args)
        {
        }

        public override void Execute()
        {
            this.List.Swap(int.Parse(this.Args[0]), int.Parse(this.Args[1]));
        }
    }
}