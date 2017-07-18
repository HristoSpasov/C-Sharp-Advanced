namespace _10.Explicit_Interfaces.Entities.Interfaces
{
    public interface IPerson
    {
        string Name { get; }
        int Age { get; }

        string GetName();
    }
}