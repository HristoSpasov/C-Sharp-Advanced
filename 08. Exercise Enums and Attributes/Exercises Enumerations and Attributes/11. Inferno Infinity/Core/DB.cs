using _11.Inferno_Infinity.Entities.Interfaces;
using System.Collections.Generic;

namespace _11.Inferno_Infinity.Core
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