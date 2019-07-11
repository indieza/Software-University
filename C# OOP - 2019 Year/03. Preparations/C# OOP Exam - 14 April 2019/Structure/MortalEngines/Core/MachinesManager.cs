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

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
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
            throw new System.NotImplementedException();
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            throw new System.NotImplementedException();
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            throw new System.NotImplementedException();
        }
    }
}