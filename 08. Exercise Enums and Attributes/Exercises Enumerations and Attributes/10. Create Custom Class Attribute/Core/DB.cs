using _10.Create_Custom_Class_Attribute.Entities.Interfaces;
using System.Collections.Generic;

namespace _10.Create_Custom_Class_Attribute.Core
{
    public class Db
    {
        private readonly IList<IWeapon> weapons;

        public Db()
        {
            this.weapons = new List<IWeapon>();
        }

        public IList<IWeapon> Weapons => this.weapons;
    }
}