namespace _02.Extended_Database.Contracts
{
    public interface IOutputStore
    {
        void AddInfo(string line);

        string GetOutput();
    }
}