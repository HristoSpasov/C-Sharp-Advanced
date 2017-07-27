using _08.Pet_Clinics.Entity.Interfaces;
using System;
using System.Collections.Generic;

namespace _08.Pet_Clinics.Entity
{
    public class Clinic : IClinic
    {
        private Room[] rooms;
        private string name;
        private int roomsCount;

        public Clinic(string name, int rooms)
        {
            this.Name = name;
            this.RoomsCount = rooms;
            this.rooms = new Room[this.RoomsCount];
            this.RoomInitializer();
        }

        public IList<IRoom> Rooms => this.rooms;

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int RoomsCount
        {
            get { return this.roomsCount; }

            private set
            {
                if (value % 2 == 0)
                {
                    throw new InvalidOperationException("Invalid Operation!");
                }

                this.roomsCount = value;
            }
        }

        public IEnumerable<IRoom> AddEnumerator() // IEnumerationStrategy<IClinic, IRoom> strategy
        {
            int leftIndex = this.RoomsCount / 2;
            int rightIndex = this.RoomsCount / 2;
            int rotationCounter = 0;

            for (int i = 0; i < this.Rooms.Count; i++)
            {
                // We are in the middle
                if (rotationCounter == 0)
                {
                    yield return this.Rooms[leftIndex];
                    rotationCounter++;
                    continue;
                }

                // Get index left or right
                if (rotationCounter % 2 != 0)
                {
                    // Move left
                    leftIndex--;
                    yield return this.Rooms[leftIndex];
                }
                else
                {
                    // Move right
                    rightIndex++;
                    yield return this.Rooms[rightIndex];
                }

                rotationCounter++;
            }
        }

        public IEnumerable<IRoom> ReleaseEnumerator()
        {
            int middleIndex = this.RoomsCount / 2;

            for (int i = middleIndex; i < this.RoomsCount; i++)
            {
                yield return this.Rooms[i];
            }

            for (int i = 0; i < middleIndex; i++)
            {
                yield return this.Rooms[i];
            }
        }

        public IEnumerator<IRoom> StandardEnumerator()
        {
            return this.Rooms.GetEnumerator();
        }

        private void RoomInitializer()
        {
            for (int i = 0; i < this.RoomsCount; i++)
            {
                this.Rooms[i] = new Room(null, false);
            }
        }
    }
}