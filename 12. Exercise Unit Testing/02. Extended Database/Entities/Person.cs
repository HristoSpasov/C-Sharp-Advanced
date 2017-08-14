using System;

namespace _02.Extended_Database.Entities
{
    public class Person
    {
        private long id;
        private string userName;

        public Person(long id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Cannot create person with empty name");
                }

                this.userName = value;
            }
        }

        public long Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Id cannot be negative!");
                }

                this.id = value;
            }
        }

        public override string ToString()
        {
            return $"(Id: {this.Id}, UserName: {this.UserName})";
        }
    }
}