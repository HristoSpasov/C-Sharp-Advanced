namespace _05.BarracksFactory_DI.Contracts
{
    public interface ICommandFactory
    {
        IExecutable CreateCommand(string[] data, IRepository repository, IUnitFactory unitFactory);
    }
}