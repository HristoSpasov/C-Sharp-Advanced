using _01HarestingFields.Utilities;
using System.Linq;
using System.Reflection;

namespace _01HarestingFields.Commands
{
    public class PublicCommand : Command
    {
        public override void Execute()
        {
            FieldInfo[] publicFields = typeof(HarvestingFields)
                .GetFields(BindingFlags.Instance | BindingFlags.Public)
                .ToArray();

            OutputGeneratorAndPrinter.AddFieldInfo(publicFields);
        }
    }
}