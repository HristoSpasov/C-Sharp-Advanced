using _03.Iterator_Test.Exceptions;
using _03.Iterator_Test.Generics;
using System;
using System.Linq;

namespace _03.Iterator_Test.Core
{
    public class Engine
    {
        private bool isRunning;
        private ListyIterator<string> list;

        public Engine()
        {
            this.isRunning = true;
        }

        public void Run()
        {
            while (this.isRunning)
            {
                string[] args = Console.ReadLine().Split();

                try
                {
                    this.ParseCommand(args);
                }
                catch (EmptyCollectionException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void ParseCommand(string[] args)
        {
            switch (args[0])
            {
                case "Create":
                    this.list = args.Length > 1
                        ? new ListyIterator<string>(args.Skip(1).ToArray())
                        : new ListyIterator<string>();
                    break;

                case "Move":
                    {
                        Console.WriteLine(this.list.Move());
                    }
                    break;

                case "HasNext":
                    {
                        Console.WriteLine(this.list.HasNext());
                    }
                    break;

                case "Print":
                    {
                        Console.WriteLine(this.list.Print());
                    }
                    break;

                default:
                    {
                        this.isRunning = false;
                    }
                    break;
            }
        }
    }
}