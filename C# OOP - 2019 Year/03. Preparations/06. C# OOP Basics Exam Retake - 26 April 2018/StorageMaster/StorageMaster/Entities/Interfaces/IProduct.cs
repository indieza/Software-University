namespace StorageMaster.Entities.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IProduct
    {
        double Price { get; }

        double Weight { get; }
    }
}