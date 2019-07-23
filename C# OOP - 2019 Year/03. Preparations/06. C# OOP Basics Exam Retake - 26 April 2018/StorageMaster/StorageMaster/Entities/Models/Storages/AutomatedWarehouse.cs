namespace StorageMaster.Entities.Models.Storages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StorageMaster.Entities.Models.Vehicles;

    public class AutomatedWarehouse : Storage
    {
        private const int InitialCapacity = 1;
        private const int InitialSlots = 2;

        private static readonly Vehicle[] DefaultVehicles =
        {
            new Truck()
        };

        public AutomatedWarehouse(string name)
            : base(name, InitialCapacity, InitialSlots, DefaultVehicles)
        {
        }
    }
}