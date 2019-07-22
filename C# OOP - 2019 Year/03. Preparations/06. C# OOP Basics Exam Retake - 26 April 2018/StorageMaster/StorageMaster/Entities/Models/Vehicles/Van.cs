namespace StorageMaster.Entities.Models.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Van : Vehicle
    {
        private const int InitialCapacity = 2;

        public Van()
            : base(InitialCapacity)
        {
        }
    }
}