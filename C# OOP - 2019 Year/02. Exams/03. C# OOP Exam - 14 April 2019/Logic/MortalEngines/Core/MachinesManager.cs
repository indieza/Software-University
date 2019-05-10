namespace MortalEngines.Core
{
    using Contracts;
    using System.Linq;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using System.Collections;
    using System.Collections.Generic;
    using MortalEngines.Common;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;
        private IList<string> machineNames;
        private IList<string> pilotNames;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
            this.machineNames = new List<string>();
            this.pilotNames = new List<string>();
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine machineOne = (IMachine)this.machines.FirstOrDefault(m => m.Name == attackingMachineName);
            IMachine machineTwo = (IMachine)this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (machineOne == null || machineTwo == null)
            {
                string name = machineOne == null ? attackingMachineName : defendingMachineName;
                return string.Format(OutputMessages.MachineNotFound, name);
            }
            else if (machineOne.HealthPoints == 0 || machineTwo.HealthPoints == 0)
            {
                string name = machineOne.HealthPoints == 0 ? attackingMachineName : defendingMachineName;
                return string.Format(OutputMessages.DeadMachineCannotAttack, name);
            }
            else
            {
                machineOne.Attack(machineTwo);
                return string.Format(OutputMessages.AttackSuccessful,
                    defendingMachineName,
                    attackingMachineName,
                    machineTwo.HealthPoints);
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = (Pilot)this.pilots
                .FirstOrDefault(p => p.Name == selectedPilotName && p.GetType().Name == "Pilot");
            IMachine machine = (BaseMachine)this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }
            else if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }
            else if (machine.Pilot != null)
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

        public string HirePilot(string name)
        {
            Pilot pilot = new Pilot(name);

            if (this.pilotNames.Contains(name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }
            else
            {
                this.pilots.Add(pilot);
                this.pilotNames.Add(name);
                return string.Format(OutputMessages.PilotHired, name);
            }
        }

        public string MachineReport(string machineName)
        {
            return this.machines.FirstOrDefault(m => m.Name == machineName).ToString();
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            IFighter fighter = new Fighter(name, attackPoints, defensePoints);

            if (this.machineNames.Contains(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                this.machines.Add(fighter);
                this.machineNames.Add(name);
                string aggressive = fighter.AggressiveMode ? "ON" : "OFF";
                return string
                    .Format(OutputMessages.FighterManufactured, name,
                    fighter.AttackPoints,
                    fighter.DefensePoints,
                    aggressive);
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            Tank tank = new Tank(name, attackPoints, defensePoints);

            if (this.machineNames.Contains(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                this.machines.Add(tank);
                this.machineNames.Add(name);
                return string.Format(OutputMessages.TankManufactured, name,
                    tank.AttackPoints,
                    tank.DefensePoints);
            }
        }

        public string PilotReport(string pilotReporting)
        {
            return this.pilots.FirstOrDefault(p => p.Name == pilotReporting).Report();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IFighter machine = (IFighter)this.machines
                .FirstOrDefault(f => f.Name == fighterName && f.GetType().Name == "Fighter");

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }
            else
            {
                machine.ToggleAggressiveMode();
                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            ITank machine = (ITank)this.machines
                .FirstOrDefault(t => t.Name == tankName && t.GetType().Name == "Tank");

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }
            else
            {
                machine.ToggleDefenseMode();
                return string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }
        }
    }
}