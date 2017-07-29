using _10.Create_Custom_Class_Attribute.Entities.Interfaces;
using _10.Create_Custom_Class_Attribute.Factories;
using System.Linq;

namespace _10.Create_Custom_Class_Attribute.Core.Command
{
    public class CreateCommand : _10.Create_Custom_Class_Attribute.Core.Command.Command
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