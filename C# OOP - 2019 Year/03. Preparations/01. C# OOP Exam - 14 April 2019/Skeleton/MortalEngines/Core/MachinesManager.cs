namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using MortalEngines.Entities.Machines.Models;
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

            IPilot pilot = new Pilot(name);
            this.pilots.Add(pilot);
            return string.Format(OutputMessages.PilotHired, pilot.Name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name && m.GetType().Name == nameof(Tank)))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            ITank tank = new Tank(name, attackPoints, defensePoints);
            this.machines.Add(tank);
            return string.Format(OutputMessages.TankManufactured,
                tank.Name,
                tank.AttackPoints,
                tank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name && m.GetType().Name == nameof(Fighter)))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);
            this.machines.Add(fighter);
            return string.Format(OutputMessages.FighterManufactured,
                fighter.Name,
                fighter.AttackPoints,
                fighter.DefensePoints,
                fighter.AggressiveMode == true ? "ON" : "OFF");
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
                return string.Format(OutputMessages.MachineHasPilotAlready, machine.Name);
            }

            machine.Pilot = pilot;
            pilot.AddMachine(machine);
            return string.Format(OutputMessages.MachineEngaged, pilot.Name, machine.Name);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attacker = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);

            if (attacker == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            IMachine defender = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (defender == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attacker.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attacker.Name);
            }

            if (defender.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defender.Name);
            }

            attacker.Attack(defender);
            return string.Format(OutputMessages.AttackSuccessful,
                defender.Name,
                attacker.Name,
                defender.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            return this.pilots.FirstOrDefault(p => p.Name == pilotReporting).Report();
        }

        public string MachineReport(string machineName)
        {
            return this.machines.FirstOrDefault(m => m.Name == machineName).ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (this.machines.FirstOrDefault(m => m.Name == fighterName && m.GetType().Name == nameof(Fighter)) == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            IFighter fighter = (Fighter)this.machines.FirstOrDefault(m => m.Name == fighterName && m.GetType().Name == nameof(Fighter));
            fighter.ToggleAggressiveMode();
            return string.Format(OutputMessages.FighterOperationSuccessful, fighter.Name);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (this.machines.FirstOrDefault(m => m.Name == tankName && m.GetType().Name == nameof(Tank)) == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            ITank tank = (Tank)this.machines.FirstOrDefault(m => m.Name == tankName && m.GetType().Name == nameof(Tank));
            tank.ToggleDefenseMode();
            return string.Format(OutputMessages.TankOperationSuccessful, tank.Name);
        }
    }
}