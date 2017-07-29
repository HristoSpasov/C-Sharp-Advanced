using _10.Create_Custom_Class_Attribute.Attributes;
using _10.Create_Custom_Class_Attribute.Entities.Weapons;
using _10.Create_Custom_Class_Attribute.Utilities;
using System.Linq;

namespace _10.Create_Custom_Class_Attribute.Core.Command
{
    public class RevisionCommand : Command
    {
        public RevisionCommand(Db database, string[] tokens) : base(database, tokens)
        {
        }

        public override void Ecexute()
        {
            int revision = typeof(Weapon)
                .GetCustomAttributes(false)
                .Select(atr => (MyCustomAttribute)atr)
                .Select(r => r.Revision)
                .First();

            OutputConsoleWriter.AddReportLine("Revision: " + revision.ToString());
        }
    }
}