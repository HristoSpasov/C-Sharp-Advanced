using _08.Custom_List.Utilities;
using System.Collections.Generic;

namespace _08.Custom_List.IO.Commands
{
    public class Print : Command
    {
        public Print(GenericList<string> list, List<string> args) : base(list, args)
        {
        }

        public override void Execute()
        {
            MakeReport.AddReportData(this.List.Print());
        }
    }
}