namespace MortalEngines.Core
{
    using MortalEngines.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private IMachinesManager manager;

        public Engine()
        {
            this.manager = new MachinesManager();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "Quit")
            {
                string[] commandItems = line.Split();
                string result = string.Empty;

                try
                {
                    switch (commandItems[0])
                    {
                        case "HirePilot":
                            result += this.manager.HirePilot(commandItems[1]);
                            break;

                        case "PilotReport":
                            result += this.manager.PilotReport(commandItems[1]);
                            break;

                        case "ManufactureTank":
                            result += this.manager.ManufactureTank(commandItems[1],
                                double.Parse(commandItems[2]),
                                double.Parse(commandItems[3]));
                            break;

                        case "ManufactureFighter":
                            result += this.manager.ManufactureFighter(commandItems[1],
                                double.Parse(commandItems[2]),
                                double.Parse(commandItems[3]));
                            break;

                        case "MachineReport":
                            result += this.manager.MachineReport(commandItems[1]);
                            break;

                        case "AggressiveMode":

                            result += this.manager.ToggleFighterAggressiveMode(commandItems[1]);
                            break;

                        case "DefenseMode":
                            result += this.manager.ToggleTankDefenseMode(commandItems[1]);
                            break;

                        case "Engage":
                            result += this.manager.EngageMachine(commandItems[1], commandItems[2]);
                            break;

                        case "Attack":
                            result += this.manager.AttackMachines(commandItems[1], commandItems[2]);
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine(result);
                line = Console.ReadLine();
            }
        }
    }
}