namespace MortalEngines.Core
{
    using MortalEngines.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly MachinesManager machinesManager;

        public Engine()
        {
            this.machinesManager = new MachinesManager();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "Quit")
            {
                string[] commandItems = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandItems[0];

                try
                {
                    switch (command)
                    {
                        case "HirePilot":
                            Console.WriteLine(this.machinesManager.HirePilot(commandItems[1]));
                            break;

                        case "PilotReport":
                            Console.WriteLine(this.machinesManager.PilotReport(commandItems[1]));
                            break;

                        case "ManufactureTank":
                            Console.WriteLine(this.machinesManager
                                .ManufactureTank(commandItems[1],
                                double.Parse(commandItems[2]),
                                double.Parse(commandItems[3])));
                            break;

                        case "ManufactureFighter":
                            Console.WriteLine(this.machinesManager
                                .ManufactureFighter(commandItems[1],
                                double.Parse(commandItems[2]),
                                double.Parse(commandItems[3])));
                            break;

                        case "MachineReport":
                            Console.WriteLine(this.machinesManager.MachineReport(commandItems[1]));
                            break;

                        case "AggressiveMode":
                            Console.WriteLine(this.machinesManager.ToggleFighterAggressiveMode(commandItems[1]));
                            break;

                        case "DefenseMode":
                            Console.WriteLine(this.machinesManager.ToggleTankDefenseMode(commandItems[1]));
                            break;

                        case "Engage":
                            Console.WriteLine(this.machinesManager.EngageMachine(commandItems[1], commandItems[2]));
                            break;

                        case "Attack":
                            Console.WriteLine(this.machinesManager
                                .AttackMachines(commandItems[1],
                                commandItems[2]));
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                line = Console.ReadLine();
            }
        }
    }
}