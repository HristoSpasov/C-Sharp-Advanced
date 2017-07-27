using System;
using System.Linq;

namespace _08.Pet_Clinics.Core
{
    public class Engine
    {
        private ClinicManager manager;

        public Engine()
        {
            this.manager = new ClinicManager();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] args = Console.ReadLine().Split();

                ParseCommand(args);
            }

            // Print result
            Console.WriteLine(Utilities.Output.GetReport());
        }

        private void ParseCommand(string[] args)
        {
            switch (args[0])
            {
                case "Create":
                    {
                        switch (args[1])
                        {
                            case "Pet":
                                {
                                    manager.CreatePet(args.Skip(2).ToList());
                                }
                                break;

                            case "Clinic":
                                {
                                    manager.CreateClinic(args.Skip(2).ToList());
                                }
                                break;
                        }
                    }
                    break;

                case "Add":
                    {
                        Utilities.Output.AddReportLine(manager.Add(args.Skip(1).ToList()).ToString());
                    }
                    break;

                case "Release":
                    {
                        Utilities.Output.AddReportLine(manager.Release(args[1]).ToString());
                    }
                    break;

                case "HasEmptyRooms":
                    {
                        Utilities.Output.AddReportLine(manager.HasEmptyRooms(args[1]).ToString());
                    }
                    break;

                case "Print":
                    {
                        if (args.Length == 2)
                        {
                            manager.Print(args[1]);
                        }
                        else
                        {
                            manager.Print(args[1], int.Parse(args[2]));
                        }
                    }
                    break;
            }
        }
    }
}