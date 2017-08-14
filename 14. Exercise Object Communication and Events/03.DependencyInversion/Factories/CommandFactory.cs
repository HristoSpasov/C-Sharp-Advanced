using _03.DependencyInversion.Core.Commands;
using _03.DependencyInversion.Interfaces;

namespace _03.DependencyInversion.Factories
{
    public class CommandFactory
    {
        public IExecutable GetCommand(ICalculator calculator, string[] args)
        {
            if (args[0] == "mode")
            {
                return new ModeCommand(args, calculator);
            }

            return new CalculateCommand(args, calculator);
        }
    }
}