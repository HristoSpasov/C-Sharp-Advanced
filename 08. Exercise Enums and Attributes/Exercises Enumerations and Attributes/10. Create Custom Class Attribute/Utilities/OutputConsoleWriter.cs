using System;
using System.Text;

namespace _10.Create_Custom_Class_Attribute.Utilities
{
    public static class OutputConsoleWriter
    {
        private static readonly StringBuilder output;

        static OutputConsoleWriter()
        {
            output = new StringBuilder();
        }

        public static void AddReportLine(string newLine)
        {
            output.AppendLine(newLine);
        }

        public static void Print()
        {
            Console.WriteLine(output.ToString().Trim());
        }
    }
}