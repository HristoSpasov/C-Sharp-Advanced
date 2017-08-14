using _03.DependencyInversion.Interfaces;

namespace _03.DependencyInversion.Core.Commands
{
    public class CalculateCommand : Command
    {
        public CalculateCommand(string[] args, ICalculator calculator) : base(args, calculator)
        {
        }

        public override string Execute()
        {
            return this.Calculator.PerformCalculation(int.Parse(this.Args[0]), int.Parse(this.Args[1])).ToString();
        }
    }
}