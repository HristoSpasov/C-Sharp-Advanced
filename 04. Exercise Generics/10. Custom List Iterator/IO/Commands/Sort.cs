using System.Collections.Generic;
using _10.Custom_List_Iterator.Generic;

namespace _10.Custom_List_Iterator.IO.Commands
{
    public class Sort : Command
    {
        public Sort(GenericList<string> list, List<string> args) : base(list, args)
        {
        }

        public override void Execute()
        {
            Sorter.Sort(this.List);
        }
    }
}
