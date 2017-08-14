using System;

namespace _02.King_s_Gambit.Entities
{
    public class Footman : Soldier
    {
        public Footman(string name) : base(name)
        {
        }

        public override void ProtectKing(object sourse, EventArgs args)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}