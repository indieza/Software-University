namespace StorageMaster.Entities.Models.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Truck : Vehicle
    {
        private const int InitialCapacity = 5;

        public Truck()
            : base(InitialCapacity)
        {
        }
    }
}