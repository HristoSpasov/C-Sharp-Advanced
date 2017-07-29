using _10.Create_Custom_Class_Attribute.Core;

namespace _10.Create_Custom_Class_Attribute
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