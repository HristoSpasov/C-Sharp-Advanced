namespace _01.Database.Contracts
{
    public interface IOutputStore
    {
        void AddInfo(string line);

        string GetOutput();
    }
}