using _02.Collection.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace _02.Collection.Generics
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int internalIndex;
        private readonly List<T> data;

        public ListyIterator()
        {
            this.data = new List<T>();
        }

        public ListyIterator(List<T> data)
        {
            this.internalIndex = 0;
            this.data = data;
        }

        public void Print()
        {
            if (this.data.Count == 0)
            {
                throw new EmptyCollectionException();
            }

            Console.WriteLine(this.data[this.internalIndex]);
        }

        public bool HasNext()
        {
            if (this.internalIndex + 1 < this.data.Count)
            {
                return true;
            }

            return false;
        }

        public bool Move()
        {
            if (this.internalIndex + 1 < this.data.Count)
            {
                this.internalIndex++;
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}