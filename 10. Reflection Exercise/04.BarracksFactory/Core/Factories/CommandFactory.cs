using _05.BarracksFactory_DI.Contracts;
using System;
using System.Linq;

namespace _05.BarracksFactory_DI.Core.Factories
{
    internal class CommandFactory : ICommandFactory
    {
        public IExecutable CreateCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            string cmdName = $"_05.BarracksFactory_DI.Core.Commands.{data[0].First().ToString().ToUpper()}{data[0].Substring(1)}Command";

            Type commandType = Type.GetType(cmdName);
            return (IExecutable)Activator.CreateInstance(commandType, new object[] { data, repository, unitFactory });
            //string cmdName = data[0];

            //switch (cmdName)
            //{
            //    case "add":
            //        return new AddCommand(data, repository, unitFactory);

            //    case "report":
            //        return new ReportCommand(data, repository, unitFactory);

            //    case "retire":
            //        return new RetireCommand(data, repository, unitFactory);

            //    default:
            //        throw new InvalidOperationException("Invalid command!");
            //}
        }
    }
}