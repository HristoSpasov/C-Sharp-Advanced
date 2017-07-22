using _10.Custom_List_Iterator.Utilities;
using System.Collections.Generic;
using _10.Custom_List_Iterator.Generic;

namespace _10.Custom_List_Iterator.IO.Commands
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