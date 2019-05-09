using MortalEngines.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            MachinesManager manager = new MachinesManager();

            string line = Console.ReadLine();

            while (line != "Quit")
            {
                string[] items = line.Split();
                string result = string.Empty;
                try
                {
                    switch (items[0])
                    {
                        case "HirePilot":
                            result = manager.HirePilot(items[1]);
                            break;
                        case "PilotReport":
                            result = manager.PilotReport(items[1]);
                            break;
                        case "ManufactureTank":
                            result = manager.ManufactureTank(items[1], double.Parse(items[2]), double.Parse(items[3]));
                            break;
                        case "ManufactureFighter":
                            result = manager.ManufactureFighter(items[1], double.Parse(items[2]), double.Parse(items[3]));
                            break;
                        case "MachineReport":
                            result = manager.MachineReport(items[1]);
                            break;
                        case "AggressiveMode":
                            result = manager.ToggleFighterAggressiveMode(items[1]);
                            break;
                        case "DefenseMode":
                            result = manager.ToggleTankDefenseMode(items[1]);
                            break;
                        case "Engage":
                            result = manager.EngageMachine(items[1], items[2]);
                            break;
                        case "Attack":
                            result = manager.AttackMachines(items[1], items[2]);
                            break;
                        default:
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine(result);

                line = Console.ReadLine();
            }
        }
    }
}
