using _01HarestingFields.Utilities;
using System.Linq;
using System.Reflection;

namespace _01HarestingFields.Commands
{
    public class PrivateCommand : Command
    {
        public override void Execute()
        {
            FieldInfo[] privateFields = typeof(HarvestingFields)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();

            OutputGeneratorAndPrinter.AddFieldInfo(privateFields);
        }
    }
}