﻿using _02.Collection.Exceptions;
using _02.Collection.Generics;
using System;
using System.Linq;

namespace _02.Collection.Core
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
            while (isRunning)
            {
                string[] args = Console.ReadLine().Split();

                try
                {
                    ParseCommand(args);
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
                        ? new ListyIterator<string>(args.Skip(1).ToList())
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
                        this.list.Print();
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