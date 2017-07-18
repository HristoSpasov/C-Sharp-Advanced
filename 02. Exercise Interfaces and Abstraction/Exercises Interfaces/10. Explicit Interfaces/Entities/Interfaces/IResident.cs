namespace _10.Explicit_Interfaces.Entities.Interfaces
{
    public interface IResident
    {
        string Name { get; }
        string Country { get; }

        string GetName();
    }
}