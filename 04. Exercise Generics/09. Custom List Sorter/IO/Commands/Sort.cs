using System.Collections.Generic;
using _09.Custom_List_Sorter.Generic;

namespace _09.Custom_List_Sorter.IO.Commands
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
