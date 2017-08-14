using _03.DependencyInversion.Interfaces;

namespace _03.DependencyInversion.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] args;
        private ICalculator calculator;

        protected Command(string[] args, ICalculator calculator)
        {
            this.args = args;
            this.calculator = calculator;
        }

        protected string[] Args
        {
            get { return this.args; }
        }

        protected ICalculator Calculator
        {
            get { return this.calculator; }
        }

        public abstract string Execute();
    }
}