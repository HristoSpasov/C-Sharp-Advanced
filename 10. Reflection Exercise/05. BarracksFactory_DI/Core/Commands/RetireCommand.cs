using _05.BarracksFactory_DI.Attributes;
using _05.BarracksFactory_DI.Contracts;
using System;

namespace _05.BarracksFactory_DI.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private readonly IRepository repository;

        public RetireCommand(string[] data, IRepository repository) : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            string report = $"{this.Data[1]} retired!";

            try
            {
                this.repository.RemoveUnit(this.Data[1]);
            }
            catch (Exception e)
            {
                report = e.Message;
            }

            return report;
        }
    }
}