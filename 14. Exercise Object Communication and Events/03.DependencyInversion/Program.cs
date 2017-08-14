using _03.DependencyInversion.Core;
using _03.DependencyInversion.Entitiies;
using _03.DependencyInversion.Interfaces;
using _03.DependencyInversion.Strategies;
using _03.DependencyInversion.Utilities;

namespace _03.DependencyInversion
{
    public class Program
    {
        public static void Main()
        {
            IStrategy defaultStrategy = new AdditionStrategy();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ICalculator calc = new PrimitiveCalculator(defaultStrategy);

            Engine engine = new Engine(reader, writer, calc);
            engine.Run();
        }
    }
}