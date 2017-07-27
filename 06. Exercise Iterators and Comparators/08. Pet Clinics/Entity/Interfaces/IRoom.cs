namespace _08.Pet_Clinics.Entity.Interfaces
{
    public interface IRoom
    {
        IPet Pet { get; set; }
        bool IsBusy { get; set; }
    }
}