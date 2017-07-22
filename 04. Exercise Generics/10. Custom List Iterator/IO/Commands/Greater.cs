using _10.Custom_List_Iterator.Utilities;
using System.Collections.Generic;
using _10.Custom_List_Iterator.Generic;

namespace _10.Custom_List_Iterator.IO.Commands
{
    public class Greater : Command
    {
        public Greater(GenericList<string> list, List<string> args) : base(list, args)
        {
        }

        public override void Execute()
        {
            MakeReport.AddReportData(this.List.Greater(this.Args[0]).ToString());
        }
    }
}