using _05.BarracksFactory_DI.Attributes;
using _05.BarracksFactory_DI.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace _05.BarracksFactory_DI.Core.Factories
{
    internal class CommandFactory : ICommandFactory
    {
        public IExecutable CreateCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            string cmdName = $"_05.BarracksFactory_DI.Core.Commands.{data[0].First().ToString().ToUpper()}{data[0].Substring(1)}Command";
            Type commandType = Type.GetType(cmdName);

            // Get all fields in target instance class, which have InjectAttribute
            var dependencies = commandType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Select(atr => new
                {
                    FieldName = atr.Name,
                    InjAtt = atr.GetCustomAttributes(false).Select(a => (InjectAttribute)a).FirstOrDefault()
                })
                .Where(a => a.InjAtt != null)
                .ToArray();

            // Params length is dependencies count + data array parameter
            object[] commandParams = new object[dependencies.Length + 1];
            commandParams[0] = data;
            int indexOFNextParam = 1;

            foreach (var dependency in dependencies)
            {
                switch (dependency.FieldName)
                {
                    case "repository":
                        commandParams[indexOFNextParam] = repository;
                        indexOFNextParam++;
                        break;

                    case "unitFactory":
                        commandParams[indexOFNextParam] = unitFactory;
                        indexOFNextParam++;
                        break;
                }
            }

            return (IExecutable)Activator.CreateInstance(commandType, commandParams);
        }
    }
}