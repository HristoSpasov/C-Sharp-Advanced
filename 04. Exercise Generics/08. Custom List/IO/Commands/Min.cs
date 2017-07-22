using _08.Custom_List.Utilities;
using System.Collections.Generic;

namespace _08.Custom_List.IO.Commands
{
    public class Min : Command
    {
        public Min(GenericList<string> list, List<string> args) : base(list, args)
        {
        }

        public override void Execute()
        {
            MakeReport.AddReportData(this.List.Min());
        }
    }
}