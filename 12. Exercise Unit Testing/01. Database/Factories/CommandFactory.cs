using _01.Database.Contracts;
using System;
using System.Reflection;

namespace _01.Database.Factories
{
    public class CommandFactory
    {
        public IExecutable GetCommand(IDatabase<int> db, string line, IOutputStore output)
        {
            string[] cmdArgs = line.Split();
            string cmdName = "_01.Database.Core.Commands." + cmdArgs[0];
            Type cmdType = Type.GetType(cmdName);
            string qualifiedName = cmdType.AssemblyQualifiedName;
            Type cmdQualifiedNameType = Type.GetType(qualifiedName);

            return (IExecutable)Activator.CreateInstance(cmdQualifiedNameType,
                BindingFlags.Instance | BindingFlags.Public, null, new object[] { db, cmdArgs, output }, null);
        }
    }
}