namespace _02.Extended_Database.Contracts
{
    public interface IDatabase<T>
    {
        void Add(T element);

        void Remove();

        T[] Fetch();

        T FindByUsername(string userName);

        T FindById(long id);
    }
}