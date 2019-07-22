namespace StorageMaster.Entities.Models.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Semi : Vehicle
    {
        private const int InitialCapacity = 10;

        public Semi()
            : base(InitialCapacity)
        {
        }
    }
}