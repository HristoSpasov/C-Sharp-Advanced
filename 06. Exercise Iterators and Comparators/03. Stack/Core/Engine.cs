using _03.Stack.Exceptions;
using _03.Stack.Generics;
using System;
using System.Linq;

namespace _03.Stack.Core
{
    public class Engine
    {
        private bool isRunning;
        private Stack<int> myStack;

        public Engine()
        {
            this.isRunning = true;
            this.myStack = new Stack<int>();
        }

        public void Run()
        {
            while (this.isRunning)
            {
                string[] line = Console.ReadLine().Split();

                switch (line[0])
                {
                    case "Push":
                        {
                            int[] argsToAdd = line
                                .ToList()
                                .Skip(1)
                                .Aggregate((current, next) => current + string.Empty + next)
                                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
                            this.myStack.Push(argsToAdd);
                        }
                        break;

                    case "Pop":
                        {
                            try
                            {
                                this.myStack.Pop();
                            }
                            catch (EmptyCollectionException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        break;

                    case "END":
                    default:
                        {
                            this.isRunning = false;
                            foreach (var element in this.myStack)
                            {
                                Console.WriteLine(element);
                            }
                        }
                        break;
                }
            }
        }
    }
}