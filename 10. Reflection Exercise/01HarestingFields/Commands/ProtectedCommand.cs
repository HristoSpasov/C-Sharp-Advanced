using _01HarestingFields.Utilities;
using System.Linq;
using System.Reflection;

namespace _01HarestingFields.Commands
{
    public class ProtectedCommand : Command
    {
        public override void Execute()
        {
            FieldInfo[] protectedFields = typeof(HarvestingFields)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsFamily)
                .ToArray();

            OutputGeneratorAndPrinter.AddFieldInfo(protectedFields);
        }
    }
}