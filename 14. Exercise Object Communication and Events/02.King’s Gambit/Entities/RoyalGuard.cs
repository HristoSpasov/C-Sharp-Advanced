using System;

namespace _02.King_s_Gambit.Entities
{
    public class RoyalGuard : Soldier
    {
        public RoyalGuard(string name) : base(name)
        {
        }

        public override void ProtectKing(object sourse, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}