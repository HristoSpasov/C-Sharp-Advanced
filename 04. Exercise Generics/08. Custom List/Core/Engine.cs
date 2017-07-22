using _08.Custom_List.IO;
using _08.Custom_List.Utilities;
using System;
using System.Linq;

namespace _08.Custom_List.Core
{
    public class Engine
    {
        private readonly CommandInterpreter interpreter;
        private readonly GenericList<string> list;

        public Engine()
        {
            this.interpreter = new CommandInterpreter();
            this.list = new GenericList<string>();
        }

        public void Run()
        {
            while (true)
            {
                string[] args = Console.ReadLine().Split("\t ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (args[0] == "END")
                {
                    break;
                }

                interpreter.InterpreteCommand(args.ToList(), this.list);
            }

            Console.WriteLine(MakeReport.GetReport());
        }
    }
}