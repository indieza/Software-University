namespace StorageMaster.Entities.Interfaces
{
    using StorageMaster.Entities.Models.Products;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IVehicle
    {
        int Capacity { get; }

        IReadOnlyCollection<IProduct> Trunk { get; }

        bool IsFull { get; }

        bool IsEmpty { get; }

        void LoadProduct(Product product);

        Product Unload();
    }
}