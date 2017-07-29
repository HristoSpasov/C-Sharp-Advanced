using _11.Inferno_Infinity.Entities.Interfaces;
using _11.Inferno_Infinity.Factories;
using System.Linq;

namespace _11.Inferno_Infinity.Core.Command
{
    public class CreateCommand : Command
    {
        public CreateCommand(Db database, string[] tokens) : base(database, tokens)
        {
        }

        public override void Ecexute()
        {
            string name = this.Tokens[1];
            string rarityType = this.Tokens[0].Split().ToArray()[0];
            string type = this.Tokens[0].Split().ToArray()[1];

            IWeapon weapon = WeaponFactory.GetWeapon(name, rarityType, type);

            this.Database.Weapons.Add(weapon);
        }
    }
}