using _10.Create_Custom_Class_Attribute.Entities.Interfaces;
using System.Linq;

namespace _10.Create_Custom_Class_Attribute.Core.Command
{
    public class RemoveCommand : _10.Create_Custom_Class_Attribute.Core.Command.Command
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