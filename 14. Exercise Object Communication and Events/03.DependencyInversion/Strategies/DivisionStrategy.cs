using System;
using _03.DependencyInversion.Attributes;
using _03.DependencyInversion.Interfaces;

namespace _03.DependencyInversion.Strategies
{
    [OperatorChange('/')]
    public class DivisionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            if (secondOperand == 0)
            {
                throw new InvalidOperationException();
            }

            return firstOperand / secondOperand;
        }
    }
}