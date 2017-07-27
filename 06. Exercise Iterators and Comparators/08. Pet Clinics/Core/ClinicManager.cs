using _08.Pet_Clinics.Entity;
using _08.Pet_Clinics.Entity.Interfaces;
using _08.Pet_Clinics.Utilities;
using System.Collections.Generic;
using System.Linq;
using InvalidOperationException = System.InvalidOperationException;

namespace _08.Pet_Clinics.Core
{
    public class ClinicManager
    {
        private IList<IPet> pets;
        private IList<IClinic> clinics;

        public ClinicManager()
        {
            this.pets = new List<IPet>();
            this.clinics = new List<IClinic>();
        }

        public void CreatePet(IList<string> petArgs)
        {
            IPet newPet = new Pet(petArgs[0], int.Parse(petArgs[1]), petArgs[2]);
            pets.Add(newPet);
        }

        public void CreateClinic(IList<string> clinicArgs)
        {
            try
            {
                IClinic clinic = new Clinic(clinicArgs[0], int.Parse(clinicArgs[1]));
                this.clinics.Add(clinic);
            }
            catch (InvalidOperationException e)
            {
                Utilities.Output.AddReportLine(e.Message);
            }
        }

        public bool Add(IList<string> addArgs)
        {
            try
            {
                IPet pet = this.pets.FirstOrDefault(n => n.Name == addArgs[0]);
                IClinic clinic = this.clinics.FirstOrDefault(n => n.Name == addArgs[1]);

                if (pet == null || clinic == null)
                {
                    throw new InvalidOperationException("Invalid Operation!");
                }

                foreach (var room in clinic.AddEnumerator())
                {
                    if (!room.IsBusy)
                    {
                        // Room is empty => add pet to room
                        room.IsBusy = true;
                        room.Pet = pet;

                        return true;
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                Utilities.Output.AddReportLine(e.Message);
            }

            // There is not place in this clinic
            return false;
        }

        public bool Release(string clinicName)
        {
            try
            {
                IClinic clinic = this.clinics.FirstOrDefault(n => n.Name == clinicName);

                if (clinic == null)
                {
                    // Clinic not found
                    throw new InvalidOperationException("Invalid Operation!");
                }

                foreach (var room in clinic.ReleaseEnumerator())
                {
                    if (room.IsBusy)
                    {
                        // Room is busy => release animal
                        room.IsBusy = false;
                        room.Pet = null;
                        return true;
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                Utilities.Output.AddReportLine(e.Message);
            }

            return false;
        }

        public bool HasEmptyRooms(string clinicName)
        {
            try
            {
                IClinic clinic = this.clinics.FirstOrDefault(n => n.Name == clinicName);

                if (clinic == null)
                {
                    // Clinic not found
                    throw new InvalidOperationException("Invalid Operation!");
                }

                foreach (var room in clinic.Rooms)
                {
                    if (!room.IsBusy)
                    {
                        // Empty room is found
                        return true;
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                Utilities.Output.AddReportLine(e.Message);
            }

            return false;
        }

        public void Print(string clinicName)
        {
            try
            {
                IClinic clinic = this.clinics.FirstOrDefault(n => n.Name == clinicName);

                if (clinic == null)
                {
                    // Clinic not found
                    throw new InvalidOperationException("Invalid Operation!");
                }

                foreach (var room in clinic.Rooms)
                {
                    Output.AddReportLine(room.IsBusy ? room.Pet.ToString() : "Room empty");
                }
            }
            catch (InvalidOperationException e)
            {
                Utilities.Output.AddReportLine(e.Message);
            }
        }

        public void Print(string clinicName, int room)
        {
            IClinic clinic = this.clinics.FirstOrDefault(n => n.Name == clinicName);

            if (clinic == null)
            {
                // Clinic not found
                throw new InvalidOperationException("Invalid Operation!");
            }

            if (room < 1 || room > clinic.RoomsCount)
            {
                // Invalid room index
                throw new InvalidOperationException("Invalid Operation!");
            }

            Output.AddReportLine(clinic.Rooms[room - 1].IsBusy ? clinic.Rooms[room - 1].Pet.ToString() : "Room empty");
        }
    }
}