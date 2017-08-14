using System;

namespace _02.King_s_Gambit.Entities
{
    public abstract class Soldier
    {
        protected Soldier(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public abstract void ProtectKing(object sourse, EventArgs args);
    }
}