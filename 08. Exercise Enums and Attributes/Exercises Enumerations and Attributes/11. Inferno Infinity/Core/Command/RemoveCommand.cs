using _11.Inferno_Infinity.Entities.Interfaces;
using System.Linq;

namespace _11.Inferno_Infinity.Core.Command
{
    public class RemoveCommand : Command
    {
        public RemoveCommand(Db database, string[] tokens) : base(database, tokens)
        {
        }

        public override void Ecexute()
        {
            string name = this.Tokens[0];
            int targetSocket = int.Parse(this.Tokens[1]);

            IWeapon weapon = this.Database.Weapons.FirstOrDefault(n => n.Name == name);

            if (weapon != null)
            {
                // Weapon exists
                weapon.RemoveGem(targetSocket);
            }
        }
    }
}