using System.Reflection;
using System.Text;

namespace _01HarestingFields.Utilities
{
    public static class OutputGeneratorAndPrinter
    {
        private static readonly StringBuilder sb;

        static OutputGeneratorAndPrinter()
        {
            sb = new StringBuilder();
        }

        public static void AddFieldInfo(FieldInfo[] fieldInfo)
        {
            foreach (var field in fieldInfo)
            {
                sb.AppendLine($"{GetAccessModifier.ReturnAccessModifier(field)} {field.FieldType.Name} {field.Name}");
            }
        }

        public static string GetReport()
        {
            return sb.ToString().Trim();
        }
    }
}