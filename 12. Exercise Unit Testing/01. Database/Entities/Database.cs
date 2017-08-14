using _01.Database.Contracts;
using System;

namespace _01.Database.Entities
{
    public class Database<T> : IDatabase<T>
    {
        private int currentIndex;
        private T[] db;

        public Database(T[] dbInput)
        {
            this.currentIndex = -1;
            this.db = dbInput;
        }

        public void Add(T element)
        {
            if (this.currentIndex >= this.db.Length)
            {
                throw new InvalidOperationException("Stack is full.");
            }

            if (this.currentIndex < 0)
            {
                this.currentIndex = 0;
            }

            // Add element to database
            this.db[this.currentIndex] = element;
            this.currentIndex++;
        }

        public T[] Fetch()
        {
            if (this.currentIndex < 0)
            {
                // Stack is empty
                return new T[0];
            }

            T[] toReturn = new T[this.currentIndex];
            for (int i = 0; i < toReturn.Length; i++)
            {
                toReturn[i] = this.db[i];
            }

            return toReturn;
        }

        public void Remove()
        {
            if (this.currentIndex - 1 < 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            // Remove elements
            this.db[--this.currentIndex] = default(T);
        }
    }
}