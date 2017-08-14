using System;

namespace _04.Bubble_Sort_Test
{
    public class BubbleSort<T> where T : IComparable<T>
    {
        private readonly T[] collection;
        private bool swapped;

        public BubbleSort(T[] collection)
        {
            this.collection = collection ?? throw new NullReferenceException("Cannot make BubbleSort instance with null collection!");
            this.swapped = false;
        }

        public T[] Sort()
        {
            do
            {
                this.swapped = false;

                for (int i = 1; i < this.collection.Length; i++)
                {
                    if (this.collection[i - 1].CompareTo(this.collection[i]) > 0)
                    {
                        this.Swap(i - 1, i);
                        this.swapped = true;
                    }
                }
            } while (this.swapped);

            return this.collection;
        }

        private void Swap(int leftIndex, int rightIndex)
        {
            T tmp = this.collection[leftIndex];
            this.collection[leftIndex] = this.collection[rightIndex];
            this.collection[rightIndex] = tmp;
        }
    }
}