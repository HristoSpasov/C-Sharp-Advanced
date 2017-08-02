using _05.BarracksFactory_DI.Attributes;
using _05.BarracksFactory_DI.Contracts;

namespace _05.BarracksFactory_DI.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private readonly IRepository repository;

        [Inject]
        private readonly IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}