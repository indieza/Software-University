namespace MortalEngines.Core
{
    using MortalEngines.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly IMachinesManager machinesManager;

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

                string result = string.Empty;

                try
                {
                    switch (commandItems[0])
                    {
                        case "HirePilot":
                            result += this.machinesManager.HirePilot(commandItems[1]);
                            break;

                        case "PilotReport":
                            result += this.machinesManager.PilotReport(commandItems[1]);
                            break;

                        case "ManufactureTank":
                            result += this.machinesManager.ManufactureTank(commandItems[1],
                                double.Parse(commandItems[2]),
                                double.Parse(commandItems[3]));
                            break;

                        case "ManufactureFighter":
                            result += this.machinesManager.ManufactureFighter(commandItems[1],
                                double.Parse(commandItems[2]),
                                double.Parse(commandItems[3]));
                            break;

                        case "MachineReport":
                            result += this.machinesManager.MachineReport(commandItems[1]);
                            break;

                        case "AggressiveMode":
                            result += this.machinesManager.ToggleFighterAggressiveMode(commandItems[1]);
                            break;

                        case "DefenseMode":
                            result += this.machinesManager.ToggleTankDefenseMode(commandItems[1]);
                            break;

                        case "Engage":
                            result += this.machinesManager.EngageMachine(commandItems[1], commandItems[2]);
                            break;

                        case "Attack":
                            result += this.machinesManager.AttackMachines(commandItems[1], commandItems[2]);
                            break;

                        default:
                            break;
                    }

                    Console.WriteLine(result);
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