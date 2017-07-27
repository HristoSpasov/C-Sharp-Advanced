using _08.Pet_Clinics.Entity.Interfaces;

namespace _08.Pet_Clinics.Entity
{
    public class Room : IRoom
    {
        private IPet pet;
        private bool isBusy;

        public Room(IPet pet, bool isBusy)
        {
            this.Pet = pet;
            this.IsBusy = isBusy;
        }

        public IPet Pet
        {
            get { return pet; }
            set { this.pet = value; }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { this.isBusy = value; }
        }
    }
}