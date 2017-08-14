using _03.DependencyInversion.Factories;
using _03.DependencyInversion.Interfaces;

namespace _03.DependencyInversion.Core
{
    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICalculator calculator;

        public Engine(IReader reader, IWriter writer, ICalculator calculator)
        {
            this.reader = reader;
            this.writer = writer;
            this.calculator = calculator;
        }

        public void Run()
        {
            while (true)
            {
                string line = reader.Read();

                if (line == "End")
                {
                    break;
                }

                IExecutable exe = new CommandFactory().GetCommand(this.calculator, line.Split());
                string result = exe.Execute();

                this.writer.Write(result);
            }
        }
    }
}