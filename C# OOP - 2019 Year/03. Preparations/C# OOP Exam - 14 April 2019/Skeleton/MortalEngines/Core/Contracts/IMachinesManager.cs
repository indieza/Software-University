namespace MortalEngines.Core.Contracts
{
    public interface IMachinesManager
    {
        string HirePilot(string name);

        string ManufactureTank(string name, double attackPoints, double defensePoints);

        string ManufactureFighter(string name, double attackPoints, double defensePoints);

        string EngageMachine(string selectedPilotName, string selectedMachineName);

        string AttackMachines(string attackingMachineName, string defendingMachineName);

        string PilotReport(string pilotReporting);

        string MachineReport(string machineName);

        string ToggleFighterAggressiveMode(string fighterName);

        string ToggleTankDefenseMode(string tankName);
    }
}