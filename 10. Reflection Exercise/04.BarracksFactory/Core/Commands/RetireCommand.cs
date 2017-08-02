using _05.BarracksFactory_DI.Contracts;
using System;

namespace _05.BarracksFactory_DI.Core.Commands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string report = $"{this.Data[1]} retired!";

            try
            {
                this.Repository.RemoveUnit(this.Data[1]);
            }
            catch (Exception e)
            {
                report = e.Message;
            }

            return report;
        }
    }
}