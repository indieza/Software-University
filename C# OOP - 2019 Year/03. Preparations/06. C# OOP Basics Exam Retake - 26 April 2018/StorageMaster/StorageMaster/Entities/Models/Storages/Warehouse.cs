namespace StorageMaster.Entities.Models.Storages
{
    using StorageMaster.Entities.Models.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Warehouse : Storage
    {
        private const int InitialCapacity = 10;
        private const int InitialSlots = 10;

        private static readonly Vehicle[] DefaultVehicles =
           {
            new Semi(),
            new Semi(),
            new Semi()
        };

        public Warehouse(string name)
            : base(name, InitialCapacity, InitialSlots, DefaultVehicles)
        {
        }
    }
}