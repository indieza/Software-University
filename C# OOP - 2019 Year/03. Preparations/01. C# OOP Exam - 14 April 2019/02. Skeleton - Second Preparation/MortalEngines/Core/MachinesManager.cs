namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilots;
        private readonly List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }
            else
            {
                IPilot pilot = new Pilot(name);
                this.pilots.Add(pilot);
                return string.Format(OutputMessages.PilotHired, name);
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name && m.GetType().Name == nameof(Tank)))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                ITank tank = new Tank(name, attackPoints, defensePoints);
                this.machines.Add(tank);
                return string.Format(OutputMessages.TankManufactured,
                    tank.Name,
                    tank.AttackPoints,
                    tank.DefensePoints);
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name && m.GetType().Name == nameof(Fighter)))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                IFighter fighter = new Fighter(name, attackPoints, defensePoints);
                this.machines.Add(fighter);
                return string.Format(OutputMessages.FighterManufactured,
                    fighter.Name,
                    fighter.AttackPoints,
                    fighter.DefensePoints,
                    fighter.AggressiveMode == true ? "ON" : "OFF");
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            IMachine machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }
            else
            {
                machine.Pilot = pilot;
                pilot.AddMachine(machine);
                return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
            }
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attacker = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);

            if (attacker == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            if (attacker.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            IMachine enemy = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (enemy == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (enemy.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }
            else
            {
                attacker.Attack(enemy);
                return string.Format(OutputMessages.AttackSuccessful,
                    defendingMachineName,
                    attackingMachineName,
                    enemy.HealthPoints);
            }
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == machineName);

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IFighter fighter = (Fighter)this.machines
                .FirstOrDefault(m => m.Name == fighterName && m.GetType().Name == nameof(Fighter));

            if (fighter != null)
            {
                fighter.ToggleAggressiveMode();
                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }
            else
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            ITank tank = (Tank)this.machines
                .FirstOrDefault(m => m.Name == tankName && m.GetType().Name == nameof(Tank));

            if (tank != null)
            {
                tank.ToggleDefenseMode();
                return string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }
            else
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }
        }
    }
}