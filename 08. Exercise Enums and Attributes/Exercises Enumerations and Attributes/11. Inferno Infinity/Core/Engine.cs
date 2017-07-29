using _11.Inferno_Infinity.Factories;
using _11.Inferno_Infinity.Utilities;

namespace _11.Inferno_Infinity.Core
{
    public class Engine
    {
        private readonly Db database;

        public Engine(Db database)
        {
            this.database = database;
        }

        public void Run()
        {
            while (true)
            {
                string[] line = InputReader.ReadLine();

                if (line[0] == "END")
                {
                    break;
                }

                // Get command and execute
                CommandFactory.GetCommand(this.database, line).Ecexute();
            }

            // Print report
            OutputConsoleWriter.Print();
        }
    }
}