namespace StorageMaster.Entities.Models.Products
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HardDrive : Product
    {
        private const double InitialWeight = 1.0;

        public HardDrive(double price)
            : base(price, InitialWeight)
        {
        }
    }
}