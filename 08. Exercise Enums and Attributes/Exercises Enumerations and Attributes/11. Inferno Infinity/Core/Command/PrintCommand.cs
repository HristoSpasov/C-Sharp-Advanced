using _11.Inferno_Infinity.Entities.Interfaces;
using System.Linq;

namespace _11.Inferno_Infinity.Core.Command
{
    public class PrintCommand : Command
    {
        public PrintCommand(Db database, string[] tokens) : base(database, tokens)
        {
        }

        public override void Ecexute()
        {
            string name = this.Tokens[0];

            IWeapon weapon = this.Database.Weapons.FirstOrDefault(n => n.Name == name);

            if (weapon != null)
            {
                weapon.Print();
            }
        }
    }
}