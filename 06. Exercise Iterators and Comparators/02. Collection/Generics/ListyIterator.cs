using System;
using System.Collections;
using System.Collections.Generic;

namespace _02.Collection.Generics
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int currentIndex;

        public ListyIterator(List<T> list)
        {
            this.List = list;
            this.Reset();
        }

        public List<T> List { get; private set; }

        public void Reset()
        {
            this.currentIndex = 0;
        }

        public bool Move()
        {
            if (this.currentIndex < this.List.Count - 1)
            {
                this.currentIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasNext()
        {
            return this.currentIndex < this.List.Count - 1;
        }

        public void Print()
        {
            if (this.List.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.List[currentIndex]);
            }
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", this.List));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T t in this.List)
            {
                yield return t;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}