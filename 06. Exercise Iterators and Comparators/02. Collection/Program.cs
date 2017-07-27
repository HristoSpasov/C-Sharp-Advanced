using _02.Collection.Generics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Collection
{
    public class Program
    {
        public static void Main()
        {
            List<string> createCommand = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            ListyIterator<string> list = new ListyIterator<string>(createCommand.GetRange(1, createCommand.Count - 1));

            string input = Console.ReadLine();

            while (input != "END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;

                    case "Print":
                        list.Print();
                        break;

                    case "PrintAll":
                        list.PrintAll();
                        break;

                    default:
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}