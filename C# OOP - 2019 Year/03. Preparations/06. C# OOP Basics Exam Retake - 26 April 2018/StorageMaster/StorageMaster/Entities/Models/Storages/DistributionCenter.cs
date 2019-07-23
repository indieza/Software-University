namespace StorageMaster.Entities.Models.Storages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StorageMaster.Entities.Models.Vehicles;

    public class DistributionCenter : Storage
    {
        private const int InitialCapacity = 2;
        private const int InitialSlots = 5;

        private static readonly Vehicle[] DefaultVehicles =
        {
            new Van(),
            new Van(),
            new Van()
        };

        public DistributionCenter(string name)
            : base(name, InitialCapacity, InitialSlots, vehicles: DefaultVehicles)
        {
        }
    }
}