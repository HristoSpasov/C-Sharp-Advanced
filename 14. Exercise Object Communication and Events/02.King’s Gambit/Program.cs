using System;
using System.Collections.Generic;
using System.Linq;
using _02.King_s_Gambit.Entities;

namespace _02.King_s_Gambit
{
    public class Program
    {
        private static King king;
        private static List<Soldier> soldiers;

        static Program()
        {
            soldiers = new List<Soldier>();
        }

        public static void Main()
        {
            // Read input
            ReadKingData();
            ReadRoyalGuards();
            ReadFootmans();

            // Process
            Run();
        }

        private static void Run()
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] args = line.Split();

                switch (args[0])
                {
                    case "Attack":
                        king.Attack();
                        break;

                    case "Kill":
                        Soldier toRemove = soldiers.First(n => n.Name == args[1]);
                        king.KingAttacked -= toRemove.ProtectKing;
                        soldiers.Remove(toRemove);
                        break;
                }
            }
        }

        private static void ReadFootmans()
        {
            string[] footmans = Console.ReadLine().Split();

            foreach (var footmanName in footmans)
            {
                Footman footman = new Footman(footmanName);
                king.KingAttacked += footman.ProtectKing;
                soldiers.Add(footman);
            }
        }

        private static void ReadRoyalGuards()
        {
            string[] guards = Console.ReadLine().Split();

            foreach (var guardName in guards)
            {
                RoyalGuard rg = new RoyalGuard(guardName);
                king.KingAttacked += rg.ProtectKing;
                soldiers.Add(rg);
            }
        }

        private static void ReadKingData()
        {
            king = new King(Console.ReadLine());
        }
    }
}