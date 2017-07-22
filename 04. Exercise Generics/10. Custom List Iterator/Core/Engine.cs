using _10.Custom_List_Iterator.IO;
using _10.Custom_List_Iterator.Utilities;
using System;
using System.Linq;
using _10.Custom_List_Iterator.Generic;

namespace _10.Custom_List_Iterator
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