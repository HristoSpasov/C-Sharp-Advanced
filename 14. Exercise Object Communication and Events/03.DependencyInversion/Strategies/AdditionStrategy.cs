using _03.DependencyInversion.Attributes;
using _03.DependencyInversion.Interfaces;

namespace _03.DependencyInversion.Strategies
{
    [OperatorChange('+')]
    public class AdditionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}