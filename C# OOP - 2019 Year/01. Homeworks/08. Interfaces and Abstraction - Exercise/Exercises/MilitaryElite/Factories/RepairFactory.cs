namespace MilitaryElite
{
    public class RepairFactory
    {
        public Repair CreateRepair(string partName, int hoursWorked)
        {
            Repair repair = new Repair(partName, hoursWorked);
            return repair;
        }
    }
}