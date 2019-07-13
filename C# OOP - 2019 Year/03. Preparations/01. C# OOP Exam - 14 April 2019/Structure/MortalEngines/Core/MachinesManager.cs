namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Models;
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
                Pilot pilot = new Pilot(name);
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
                Tank tank = new Tank(name, attackPoints, defensePoints);
                this.machines.Add(tank);

                return string.Format(OutputMessages.TankManufactured,
                    tank.Name,
                    tank.AttackPoints,
                    tank.DefensePoints);
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(f => f.Name == name && f.GetType().Name == nameof(Fighter)))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                Fighter fighter = new Fighter(name, attackPoints, defensePoints);
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
            Pilot pilot = (Pilot)this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);

            BaseMachine machine = (BaseMachine)this.machines.FirstOrDefault(p => p.Name == selectedMachineName);

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

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            BaseMachine attackingMachine = (BaseMachine)this.machines
                .FirstOrDefault(m => m.Name == attackingMachineName);

            BaseMachine defendingMachine = (BaseMachine)this.machines
                .FirstOrDefault(m => m.Name == defendingMachineName);

            if (attackingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            else if (defendingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }
            else if (attackingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            else if (defendingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }
            else
            {
                attackingMachine.Attack(defendingMachine);

                return string.Format(OutputMessages.AttackSuccessful,
                    defendingMachineName,
                    attackingMachineName,
                    defendingMachine.HealthPoints);
            }
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            if (pilot != null)
            {
                return pilot.Report();
            }
            else
            {
                return string.Format(OutputMessages.PilotNotFound, pilotReporting);
            }
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == machineName);

            if (machine != null)
            {
                return machine.ToString();
            }
            else
            {
                return string.Format(OutputMessages.MachineNotFound, machineName);
            }
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IFighter targetFighter = (IFighter)this.machines
                   .FirstOrDefault(f => f.Name == fighterName && f.GetType().Name == nameof(Fighter));

            if (targetFighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }
            else
            {
                targetFighter.ToggleAggressiveMode();
                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            ITank targetTank = (ITank)this.machines
                   .FirstOrDefault(m => m.Name == tankName && m.GetType().Name == nameof(Tank));

            if (targetTank == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }
            else
            {
                targetTank.ToggleDefenseMode();
                return string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }
        }
    }
}