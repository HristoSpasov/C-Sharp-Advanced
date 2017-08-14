using System;
using System.Linq;
using System.Reflection;
using _04.WorkForce.Attributes;
using _04.WorkForce.Core.Commands;
using _04.WorkForce.Entities;

namespace _04.WorkForce.Factories
{
    public class CommandFactory
    {
        public Command GetCommand(string[] cmdArgs, EmployeeCollection employeeCollection, JobCollection jobCollection)
        {
            Command commandToReturn = null;
            object[] commandCtorObjects = new object[] { cmdArgs, employeeCollection, jobCollection };

            Type[] types = Assembly
                .GetExecutingAssembly()
                .GetTypes();

            foreach (var type in types)
            {
                CommandAttribute attr = type
                    .GetCustomAttributes(false)
                    .Select(atr => (CommandAttribute)atr)
                    .FirstOrDefault();

                if (attr != null && type.Name == cmdArgs[0])
                {
                    commandToReturn = (Command)Activator.CreateInstance(type, BindingFlags.Public | BindingFlags.Instance, null, commandCtorObjects, null);
                    break;
                }
            }

            return commandToReturn;
        }
    }
}