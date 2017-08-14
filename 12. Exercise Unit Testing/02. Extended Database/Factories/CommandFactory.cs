using _02.Extended_Database.Contracts;
using _02.Extended_Database.Entities;
using System;
using System.Reflection;

namespace _02.Extended_Database.Factories
{
    public class CommandFactory
    {
        public IExecutable GetCommand(IDatabase<Person> db, string line, IOutputStore output)
        {
            string[] cmdArgs = line.Split();
            string cmdName = "_02.Extended_Database.Core.Commands." + cmdArgs[0];
            Type cmdType = Type.GetType(cmdName);
            string qualifiedName = cmdType.AssemblyQualifiedName;
            Type cmdQualifiedNameType = Type.GetType(qualifiedName);

            return (IExecutable)Activator.CreateInstance(cmdQualifiedNameType,
                BindingFlags.Instance | BindingFlags.Public, null, new object[] { db, cmdArgs, output }, null);
        }
    }
}