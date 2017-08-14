using _03.Iterator_Test.Exceptions;
using System.Collections;
using System.Collections.Generic;

namespace _03.Iterator_Test.Generics
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int internalIndex;
        private readonly T[] data;

        public ListyIterator()
        {
            this.data = new T[0];
        }

        public ListyIterator(T[] data)
        {
            this.internalIndex = 0;
            this.data = data;
        }

        public string Print()
        {
            if (this.data.Length == 0)
            {
                throw new EmptyCollectionException();
            }

            return this.data[this.internalIndex].ToString();
        }

        public bool HasNext()
        {
            if (this.internalIndex + 1 < this.data.Length)
            {
                return true;
            }

            return false;
        }

        public bool Move()
        {
            if (this.internalIndex + 1 < this.data.Length)
            {
                this.internalIndex++;
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)this.data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}