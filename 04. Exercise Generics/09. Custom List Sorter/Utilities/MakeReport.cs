using System.Text;

namespace _09.Custom_List_Sorter.Utilities
{
    public static class MakeReport
    {
        private static StringBuilder report;

        static MakeReport()
        {
            report = new StringBuilder();
        }

        public static void AddReportData(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                report.AppendLine(str.Trim());
            }
        }

        public static string GetReport()
        {
            return report.ToString().Trim();
        }
    }
}