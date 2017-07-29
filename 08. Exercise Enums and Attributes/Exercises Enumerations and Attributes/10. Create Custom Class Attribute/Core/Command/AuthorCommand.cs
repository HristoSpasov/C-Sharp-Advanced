using _10.Create_Custom_Class_Attribute.Attributes;
using _10.Create_Custom_Class_Attribute.Entities.Weapons;
using _10.Create_Custom_Class_Attribute.Utilities;
using System.Linq;

namespace _10.Create_Custom_Class_Attribute.Core.Command
{
    public class AuthorCommand : Command
    {
        public AuthorCommand(Db database, string[] tokens) : base(database, tokens)
        {
        }

        public override void Ecexute()
        {
            string author = typeof(Weapon)
                .GetCustomAttributes(false)
                .Select(atr => (MyCustomAttribute)atr)
                .Select(a => a.Author)
                .First();

            OutputConsoleWriter.AddReportLine("Author: " + author);
        }
    }
}