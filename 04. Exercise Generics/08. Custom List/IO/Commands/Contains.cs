using _08.Custom_List.Utilities;
using System.Collections.Generic;

namespace _08.Custom_List.IO.Commands
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