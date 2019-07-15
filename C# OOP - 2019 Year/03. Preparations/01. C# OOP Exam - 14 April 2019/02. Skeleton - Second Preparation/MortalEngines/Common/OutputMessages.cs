namespace MortalEngines.Common
{
    public class OutputMessages
    {
        public const string PilotHired = "Pilot {0} hired";

        public const string PilotExists = "Pilot {0} is hired already";

        public const string TankManufactured = "Tank {0} manufactured - attack: {1:F2}; defense: {2:F2}";

        public const string FighterManufactured = "Fighter {0} manufactured - attack: {1:F2}; defense: {2:F2}; aggressive: {3}";

        public const string MachineExists = "Machine {0} is manufactured already";

        public const string MachineHasPilotAlready = "Machine {0} is already occupied";

        public const string PilotNotFound = "Pilot {0} could not be found";

        public const string MachineNotFound = "Machine {0} could not be found";

        public const string MachineEngaged = "Pilot {0} engaged machine {1}";

        public const string FighterOperationSuccessful = "Fighter {0} toggled aggressive mode";

        public const string TankOperationSuccessful = "Tank {0} toggled defense mode";

        public const string AttackSuccessful = "Machine {0} was attacked by machine {1} - current health: {2:F2}";

        public const string DeadMachineCannotAttack = "Dead machine {0} cannot attack or be attacked";
    }
}