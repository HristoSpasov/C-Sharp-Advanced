using _05.BarracksFactory_DI.Attributes;
using _05.BarracksFactory_DI.Contracts;

namespace _05.BarracksFactory_DI.Core.Commands
{
    public class ReportCommand : Command
    {
        [Inject]
        private readonly IRepository repository;

        public ReportCommand(string[] data, IRepository repository) : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}