using _08.Custom_List.Utilities;
using System.Collections.Generic;

namespace _08.Custom_List.IO.Commands
{
    public class Remove : Command
    {
        public Remove(GenericList<string> list, List<string> args) : base(list, args)
        {
        }

        public override void Execute()
        {
            this.List.Remove(int.Parse(this.Args[0]));
        }
    }
}