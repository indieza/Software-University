namespace MortalEngines.Core
{
    using Contracts;
    using System.Linq;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using System.Collections;
    using System.Collections.Generic;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<ITank> tanks;
        private IList<IFighter> fighters;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.tanks = new List<ITank>();
            this.fighters = new List<IFighter>();
        }

        public string HirePilot(string name)
        {
            Pilot pilot = new Pilot(name);

            if (pilots.Contains(pilot))
            {
                return $"Pilot {name} is hired already";
            }
            else
            {
                pilots.Add(pilot);
                return $"Pilot {name} hired";
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            Tank tank = new Tank(name, attackPoints, defensePoints);

            if (tanks.Contains(tank))
            {
                return $"Machine {name} is manufactured already";
            }
            else
            {
                tanks.Add(tank);
                return $"Tank {name} manufactured - attack: {attackPoints}; defense: {defensePoints}";
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            Fighter fighter = new Fighter(name, attackPoints, defensePoints);

            if (fighters.Contains(fighter))
            {
                return $"Machine {name} is manufactured already";
            }
            else
            {
                fighters.Add(fighter);
                return $"Fighter {name} manufactured - attack: {attackPoints}; defense: {defensePoints}; aggressive: ON";
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            throw new System.NotImplementedException();
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            foreach (var fighter in fighters)
            {
                if (fighter.Name == fighterName)
                {
                    fighter.ToggleAggressiveMode();
                    return $"Fighter {fighterName} toggled aggressive mode";
                }
            }

            return $"Machine {fighterName} could not be found";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            foreach (var tank in tanks)
            {
                if (tank.Name == tankName)
                {
                    tank.ToggleDefenseMode();
                    return $"Tank {tankName} toggled defense mode";
                }
            }

            return $"Machine {tankName} could not be found";
        }
    }
}