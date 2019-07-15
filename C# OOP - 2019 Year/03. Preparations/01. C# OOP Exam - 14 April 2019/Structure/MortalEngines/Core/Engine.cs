namespace MortalEngines.Core
{
    using MortalEngines.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

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

                string result = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "HirePilot":
                            {
                                string name = commandItems[1];
                                result += this.machinesManager.HirePilot(name);
                            }
                            break;

                        case "PilotReport":
                            {
                                string name = commandItems[1];
                                result += this.machinesManager.PilotReport(name);
                            }
                            break;

                        case "ManufactureTank":
                            {
                                string name = commandItems[1];
                                double attack = double.Parse(commandItems[2]);
                                double defense = double.Parse(commandItems[3]);

                                result += this.machinesManager.ManufactureTank(name, attack, defense);
                            }
                            break;

                        case "ManufactureFighter":
                            {
                                string name = commandItems[1];
                                double attack = double.Parse(commandItems[2]);
                                double defense = double.Parse(commandItems[3]);

                                result += this.machinesManager.ManufactureFighter(name, attack, defense);
                            }
                            break;

                        case "MachineReport":
                            {
                                string name = commandItems[1];
                                result += this.machinesManager.MachineReport(name);
                            }
                            break;

                        case "AggressiveMode":
                            {
                                string name = commandItems[1];
                                result += this.machinesManager.ToggleFighterAggressiveMode(name);
                            }
                            break;

                        case "DefenseMode":
                            {
                                string name = commandItems[1];
                                this.machinesManager.ToggleTankDefenseMode(name);
                            }
                            break;

                        case "Engage":
                            {
                                string pilot = commandItems[1];
                                string machine = commandItems[2];
                                result += this.machinesManager.EngageMachine(pilot, machine);
                            }
                            break;

                        case "Attack":
                            {
                                string attacker = commandItems[1];
                                string defender = commandItems[2];
                                result += this.machinesManager.AttackMachines(attacker, defender);
                            }
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(result);

                line = Console.ReadLine();
            }
        }
    }
}