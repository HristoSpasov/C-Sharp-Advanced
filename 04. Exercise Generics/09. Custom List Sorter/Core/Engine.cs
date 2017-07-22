using _09.Custom_List_Sorter.IO;
using _09.Custom_List_Sorter.Utilities;
using System;
using System.Linq;
using _09.Custom_List_Sorter.Generic;

namespace _09.Custom_List_Sorter.Core
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
                string[] args = Console.ReadLine().Split();

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