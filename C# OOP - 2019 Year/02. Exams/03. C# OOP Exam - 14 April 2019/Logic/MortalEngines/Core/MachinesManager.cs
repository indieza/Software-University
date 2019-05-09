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
        private IList<ITank> tanks;
        private IList<IFighter> fighters;
        private IList<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.tanks = new List<ITank>();
            this.fighters = new List<IFighter>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            Pilot pilot = new Pilot(name);

            if (pilots.Contains(pilot))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }
            else
            {
                pilots.Add(pilot);
                return string.Format(OutputMessages.PilotHired, name);
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            Tank tank = new Tank(name, attackPoints, defensePoints);

            if (tanks.Contains(tank))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                tanks.Add(tank);
                return string.Format(OutputMessages.TankManufactured, name, attackPoints, defensePoints);
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            Fighter fighter = new Fighter(name, attackPoints, defensePoints);

            if (fighters.Contains(fighter))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                fighters.Add(fighter);
                return string.Format(OutputMessages.FighterManufactured, name, attackPoints, defensePoints, fighter.AggressiveMode == true ? "ON" : "OFF");
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            throw new System.NotImplementedException();
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine machineOne = machines.FirstOrDefault(m => m.Name == attackingMachineName);
            IMachine machineTwo = machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (machineOne == null)
            {
                return string.Format(OutputMessages.MachineNotFound, machineOne.Name);
            }
            else if (machineTwo == null)
            {
                return string.Format(OutputMessages.MachineNotFound, machineTwo.Name);
            }
            else if (machineOne.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, machineOne.Name);
            }
            else if (machineTwo.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, machineTwo.Name);
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

        public string PilotReport(string pilotReporting)
        {
            string result = string.Empty;

            foreach (var pilot in pilots)
            {
                if (pilot.Name == pilotReporting)
                {
                    result = pilot.Report();
                }
            }

            return result;
        }

        public string MachineReport(string machineName)
        {
            string result = string.Empty;

            foreach (var machine in machines)
            {
                if (machine.Name == machineName)
                {
                    result = machine.ToString();
                }
            }

            return result.TrimEnd();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            foreach (var fighter in fighters)
            {
                if (fighter.Name == fighterName)
                {
                    fighter.ToggleAggressiveMode();
                    return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
                }
            }

            return string.Format(OutputMessages.MachineNotFound, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            foreach (var tank in tanks)
            {
                if (tank.Name == tankName)
                {
                    tank.ToggleDefenseMode();
                    return string.Format(OutputMessages.TankOperationSuccessful, tankName);
                }
            }

            return string.Format(OutputMessages.MachineNotFound, tankName);
        }
    }
}