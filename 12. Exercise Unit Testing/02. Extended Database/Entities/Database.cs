using _02.Extended_Database.Contracts;
using System;

namespace _02.Extended_Database.Entities
{
    public class Database<T> : IDatabase<T>
        where T : Person
    {
        private int currentIndex;
        private readonly T[] db;

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

            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.db[i].Id == element.Id)
                {
                    throw new InvalidOperationException("Person with that id already exist.");
                }

                if (this.db[i].UserName == element.UserName)
                {
                    throw new InvalidOperationException("Person with that user name already exist.");
                }
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

        public T FindByUsername(string userName)
        {
            // Validate parameter
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Username cannot be null or empty.");
            }

            // Search for user name
            T person = null;
            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.db[i].UserName == userName)
                {
                    person = this.db[i];
                    break;
                }
            }

            if (person == null)
            {
                throw new InvalidOperationException("No person found with such user name");
            }

            return person;
        }

        public T FindById(long id)
        {
            // Validate parameter
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be negative.");
            }

            // Search for person
            T person = null;
            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.db[i].Id == id)
                {
                    person = this.db[i];
                    break;
                }
            }

            if (person == null)
            {
                throw new InvalidOperationException("No person found with such id");
            }

            return person;
        }
    }
}