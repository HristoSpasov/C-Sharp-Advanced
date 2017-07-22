using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Custom_List_Sorter.Generic
{
    public class GenericList<T>
        where T : IComparable<T>
    {
        private readonly List<T> genericList;

        public GenericList()
        {
            this.genericList = new List<T>();
        }

        public void Add(T element)
        {
            if (element != null)
            {
                this.genericList.Add(element);
            }
        }

        public T Remove(int index)
        {
            if (index > this.genericList.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            T elementToRemove = this.genericList[index];
            this.genericList.RemoveAt(index);
            return elementToRemove;
        }

        public bool Contains(T element)
        {
            return this.genericList.Any(s => s.Equals(element));
        }

        public void Swap(int index1, int index2)
        {
            if (index1 > this.genericList.Count - 1 || index2 > this.genericList.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            T tmp = this.genericList[index1];
            this.genericList[index1] = this.genericList[index2];
            this.genericList[index2] = tmp;
        }

        public int Greater(T element)
        {
            return this.genericList.Count(s => s.CompareTo(element) == 1);
        }

        public T Max()
        {
            return this.genericList.Max();
        }

        public T Min()
        {
            return this.genericList.Min();
        }

        public string Print()
        {
            return string.Join(Environment.NewLine, this.genericList);
        }

        public void Sort()
        {
            this.genericList.Sort();
        }
    }
}