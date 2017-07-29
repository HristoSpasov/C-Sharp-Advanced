using _10.Create_Custom_Class_Attribute.Attributes;
using _10.Create_Custom_Class_Attribute.Entities.Weapons;
using _10.Create_Custom_Class_Attribute.Utilities;
using System.Linq;

namespace _10.Create_Custom_Class_Attribute.Core.Command
{
    public class ReviewersCommand : Command
    {
        public ReviewersCommand(Db database, string[] tokens) : base(database, tokens)
        {
        }

        public override void Ecexute()
        {
            string[] reviewers = typeof(Weapon)
                .GetCustomAttributes(false)
                .Select(atr => (MyCustomAttribute)atr)
                .Select(r => r.Reviewers)
                .First();

            OutputConsoleWriter.AddReportLine("Reviewers: " + string.Join(", ", reviewers));
        }
    }
}