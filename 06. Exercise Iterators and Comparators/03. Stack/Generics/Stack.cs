using _03.Stack.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace _03.Stack.Generics
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] data;

        public Stack(T[] data)
        {
            this.data = data;
        }

        public Stack()
        {
            this.data = new T[0];
        }

        public void Push(T[] elements)
        {
            // Resize array to fit all new elements if necessary
            Array.Resize(ref this.data, this.data.Length + elements.Length);

            // Copy new elements to end
            int j = 0;
            for (int i = this.data.Length - elements.Length; i < this.data.Length; i++)
            {
                this.data[i] = elements[j];
                j++;
            }
        }

        public void Pop()
        {
            if (this.data.Length == 0)
            {
                throw new EmptyCollectionException();
            }

            // Remove last element and rezize array
            Array.Resize(ref this.data, this.data.Length - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int loopCounter = 2;
            while (loopCounter != 0)
            {
                for (int i = this.data.Length - 1; i >= 0; i--)
                {
                    yield return this.data[i];
                }

                loopCounter--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}