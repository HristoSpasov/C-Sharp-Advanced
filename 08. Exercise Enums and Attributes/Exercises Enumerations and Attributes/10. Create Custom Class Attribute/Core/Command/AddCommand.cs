﻿using _10.Create_Custom_Class_Attribute.Entities.Interfaces;
using _10.Create_Custom_Class_Attribute.Factories;
using System.Linq;

namespace _10.Create_Custom_Class_Attribute.Core.Command
{
    public class AddCommand : Command
    {
        public AddCommand(Db database, string[] tokens) : base(database, tokens)
        {
        }

        public override void Ecexute()
        {
            // Input tokens
            string name = this.Tokens[0];
            int targetSocket = int.Parse(this.Tokens[1]);
            string gemLevelOfQuality = this.Tokens[2].Split().ToArray()[0];
            string gemType = this.Tokens[2].Split().ToArray()[1];

            IGem gem = GemFactory.GetGem(gemType, gemLevelOfQuality); // Get new gem
            IWeapon weapon = this.Database.Weapons.FirstOrDefault(n => n.Name == name); // Search for weapon

            if (gem != null && weapon != null)
            {
                // Both gem and weapon are not null
                weapon.AddGem(targetSocket, gem);
            }
        }
    }
}