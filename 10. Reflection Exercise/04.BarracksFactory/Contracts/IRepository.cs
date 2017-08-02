namespace _05.BarracksFactory_DI.Contracts
{
    public interface IRepository
    {
        void AddUnit(IUnit unit);

        string Statistics { get; }

        void RemoveUnit(string unitType);
    }
}