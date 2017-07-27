using System.Collections.Generic;

namespace _08.Pet_Clinics.Entity.Interfaces
{
    public interface IClinic
    {
        string Name { get; }
        IList<IRoom> Rooms { get; }
        int RoomsCount { get; }

        IEnumerable<IRoom> AddEnumerator();

        IEnumerable<IRoom> ReleaseEnumerator();
    }
}