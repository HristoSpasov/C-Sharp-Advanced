using _08.Military_Elite.Core;
using _08.Military_Elite.Entities;
using _08.Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.Military_Elite.Factories
{
    public static class UnitFactory
    {
        private static StringBuilder exceptions;

        static UnitFactory()
        {
            exceptions = new StringBuilder();
        }

        public static ISoldier GetUnit(List<string> args, MilitaryEliteManager manager)
        {
            string type = args[0];
            args.RemoveAt(0);

            switch (type)
            {
                case "Private":
                    return new Private(args[0], args[1], args[2], double.Parse(args[3]));

                case "LeutenantGeneral":
                    {
                        LeutenantGeneral newSoldier = new LeutenantGeneral(args[0], args[1], args[2], double.Parse(args[3]));
                        List<string> privatesToAdd = args.Skip(4).ToList();
                        foreach (var privateSoldierId in privatesToAdd)
                        {
                            newSoldier.AddPrivate(manager.GetSoldier(privateSoldierId));
                        }

                        return newSoldier;
                    }

                case "Engineer":
                    {
                        try
                        {
                            Engineer newEngineer = new Engineer(args[0], args[1], args[2], double.Parse(args[3]), args[4]);

                            List<string> parts = args.Skip(5).ToList();

                            for (int i = 0; i < parts.Count; i += 2)
                            {
                                string partName = parts[i];
                                int hours = int.Parse(parts[i + 1]);

                                IRepair newRepair = new Repair(partName, hours);
                                newEngineer.AddRepair(newRepair);
                            }

                            return newEngineer;
                        }
                        catch (ArgumentException e)
                        {
                            exceptions.AppendLine(e.Message);
                        }
                    }
                    break;

                case "Commando":
                    {
                        try
                        {
                            Commando newCommando = new Commando(args[0], args[1], args[2], double.Parse(args[3]), args[4]);

                            List<string> missions = args.Skip(5).ToList();

                            for (int i = 0; i < missions.Count; i += 2)
                            {
                                string missionName = missions[i];
                                string missionState = missions[i + 1];

                                try
                                {
                                    IMission newMission = new Mission(missionName, missionState);
                                    newCommando.AddRepair(newMission);
                                }
                                catch (ArgumentException e)
                                {
                                    exceptions.AppendLine(e.Message);
                                }
                            }

                            return newCommando;
                        }
                        catch (ArgumentException e)
                        {
                            exceptions.AppendLine(e.Message);
                        }
                    }
                    break;

                case "Spy":
                default:
                    {
                        return new Spy(args[0], args[1], args[2], int.Parse(args[3]));
                    }
            }

            return null;
        }
    }
}