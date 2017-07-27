using _09.Linked_List_Traversal.Exceptions;
using System.Collections;
using System.Collections.Generic;

namespace _09.Linked_List_Traversal
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        private Node<T> HeadNode { get; set; }
        private Node<T> TailNode { get; set; }

        private class Node<T>
        {
            public T Value { get; private set; }
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }
        }

        public MyLinkedList()
        {
            // Empty ctor
        }

        public void Add(T element)
        {
            Node<T> newNode = new Node<T>(element); // Create new node

            if (this.Count == 0)
            {
                // There are no elements in the collection
                this.HeadNode = newNode;
                this.TailNode = newNode;
            }
            else
            {
                // Add new node at the end
                this.TailNode.Next = newNode; // Set next of the tail node to be new node
                newNode.Previous = this.TailNode; // Set new node previous to current tail
                this.TailNode = newNode; // Set new node to be the tail of the collection
            }

            // Increace elements in collection
            this.Count++;
        }

        public void Remove(T element)
        {
            Node<T> toRemove = this.HeadNode;

            // Loop to find firs element equal to T element
            while (toRemove != null)
            {
                if (toRemove.Value.Equals(element))
                {
                    break;
                }

                toRemove = toRemove.Next;
            }

            if (toRemove != null)
            {
                if (this.Count == 0)
                {
                    throw new EmptyCollectionException();
                }

                if (this.Count == 1)
                {
                    this.HeadNode = null;
                    this.TailNode = null;
                }
                else
                {
                    // Change pointers
                    if (toRemove.Previous == null)
                    {
                        this.HeadNode = toRemove.Next;
                    }
                    else
                    {
                        toRemove.Previous.Next = toRemove.Next;
                    }

                    if (toRemove.Next == null)
                    {
                        this.TailNode = toRemove.Previous;
                    }
                    else
                    {
                        toRemove.Next.Previous = toRemove.Previous;
                    }
                }

                // Decrease elements
                this.Count--;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = this.HeadNode;

            while (node != null)
            {
                yield return node.Value;

                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}