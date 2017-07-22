using _10.Custom_List_Iterator.Utilities;
using System.Collections.Generic;
using _10.Custom_List_Iterator.Generic;

namespace _10.Custom_List_Iterator.IO.Commands
{
    public class Contains : Command
    {
        public Contains(GenericList<string> list, List<string> args) : base(list, args)
        {
        }

        public override void Execute()
        {
            MakeReport.AddReportData(this.List.Contains(this.Args[0]).ToString());
        }
    }
}