namespace _03.DependencyInversion.Interfaces
{
    public interface ICalculator
    {
        void ChangeStrategy(char oper);

        int PerformCalculation(int firstOperand, int secondOperand);
    }
}