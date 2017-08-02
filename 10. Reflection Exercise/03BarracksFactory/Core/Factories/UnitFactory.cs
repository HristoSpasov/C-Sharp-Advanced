namespace _05.BarracksFactory_DI.Core.Factories
{
    using Contracts;
    using System;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type type = Type.GetType("_05.BarracksFactory_DI.Models.Units." + unitType); // Get type from given string
            string qualifiedName = type.AssemblyQualifiedName; // Get qualified name
            return (IUnit)Activator.CreateInstance(Type.GetType(qualifiedName));

            ////TODO: implement for Problem 3
            //throw new NotImplementedException();
        }
    }
}