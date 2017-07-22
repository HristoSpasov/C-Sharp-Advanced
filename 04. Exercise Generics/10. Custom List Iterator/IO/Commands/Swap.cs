using System.Collections.Generic;
using _10.Custom_List_Iterator.Generic;

namespace _10.Custom_List_Iterator.IO.Commands
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