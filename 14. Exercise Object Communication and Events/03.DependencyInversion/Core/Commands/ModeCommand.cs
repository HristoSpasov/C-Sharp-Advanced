using _03.DependencyInversion.Interfaces;

namespace _03.DependencyInversion.Core.Commands
{
    public class ModeCommand : Command
    {
        public ModeCommand(string[] args, ICalculator calculator) : base(args, calculator)
        {
        }

        public override string Execute()
        {
            this.Calculator.ChangeStrategy(char.Parse(this.Args[1]));

            return null;
        }
    }
}