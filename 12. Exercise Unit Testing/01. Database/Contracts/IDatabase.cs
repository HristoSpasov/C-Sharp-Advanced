namespace _01.Database.Contracts
{
    public interface IDatabase<T>
    {
        void Add(T element);

        void Remove();

        T[] Fetch();
    }
}