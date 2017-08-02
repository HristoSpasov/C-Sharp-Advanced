namespace _05.BarracksFactory_DI
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;

    internal class AppEntryPoint
    {
        private static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}