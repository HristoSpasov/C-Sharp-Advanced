using _11.Inferno_Infinity.Core;

namespace _11.Inferno_Infinity
{
    public class Program
    {
        private static readonly Db database;

        static Program()
        {
            database = new Db();
        }

        public static void Main()
        {
            Engine engine = new Engine(database);
            engine.Run();
        }
    }
}