using System;
using System.Linq;
using System.Reflection;
using _03.DependencyInversion.Attributes;
using _03.DependencyInversion.Interfaces;

namespace _03.DependencyInversion.Entitiies
{
    public class PrimitiveCalculator : ICalculator
    {
        private IStrategy strategy;

        public PrimitiveCalculator(IStrategy defaultStrategy)
        {
            this.strategy = defaultStrategy;
        }

        public void ChangeStrategy(char oper)
        {
            var types = Assembly
                .GetExecutingAssembly()
                .GetTypes();

            foreach (var type in types)
            {
                object[] attrs = type.GetCustomAttributes(typeof(OperatorChangeAttribute), true);

                if (attrs.Length > 0)
                {
                    OperatorChangeAttribute operatorChangeAttribute = attrs.Select(attr => (OperatorChangeAttribute)attr).First();
                    char operatorValue = (char)operatorChangeAttribute.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)[0].GetValue(operatorChangeAttribute);

                    if (operatorValue == oper)
                    {
                        this.strategy = (IStrategy)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public, null, new object[0], null);
                    }
                }
            }
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return strategy.Calculate(firstOperand, secondOperand);
        }
    }
}