using System.Text;

namespace _08.Pet_Clinics.Utilities
{
    public static class Output
    {
        private static readonly StringBuilder output;

        static Output()
        {
            output = new StringBuilder();
        }

        public static void AddReportLine(string line)
        {
            output.AppendLine(line);
        }

        public static string GetReport()
        {
            return output.ToString().Trim();
        }
    }
}