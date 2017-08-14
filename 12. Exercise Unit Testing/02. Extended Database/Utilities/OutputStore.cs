using _02.Extended_Database.Contracts;
using System.Text;

namespace _02.Extended_Database.Utilities
{
    public class OutputStore : IOutputStore
    {
        private readonly StringBuilder output;

        public OutputStore()
        {
            this.output = new StringBuilder();
        }

        public void AddInfo(string line)
        {
            this.output.AppendLine(line);
        }

        public string GetOutput()
        {
            return this.output.ToString().Trim();
        }
    }
}