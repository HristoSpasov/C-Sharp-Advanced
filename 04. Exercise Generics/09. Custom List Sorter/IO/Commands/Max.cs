﻿using _09.Custom_List_Sorter.Utilities;
using System.Collections.Generic;
using _09.Custom_List_Sorter.Generic;

namespace _09.Custom_List_Sorter.IO.Commands
{
    public class Max : Command
    {
        public Max(GenericList<string> list, List<string> args) : base(list, args)
        {
        }

        public override void Execute()
        {
            MakeReport.AddReportData(this.List.Max());
        }
    }
}