using _01HarestingFields.Utilities;
using System.Linq;
using System.Reflection;

namespace _01HarestingFields.Commands
{
    public class AllCommand : Command
    {
        public override void Execute()
        {
            FieldInfo[] allFields = typeof(HarvestingFields)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .ToArray();

            OutputGeneratorAndPrinter.AddFieldInfo(allFields);
        }
    }
}