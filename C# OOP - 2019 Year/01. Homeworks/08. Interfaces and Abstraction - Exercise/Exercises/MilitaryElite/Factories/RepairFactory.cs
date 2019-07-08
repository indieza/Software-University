namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RepairFactory
    {
        public Repair MakeRepair(string partName, int hoursWorked)
        {
            Repair repair = new Repair(partName, hoursWorked);

            return repair;
        }
    }
}