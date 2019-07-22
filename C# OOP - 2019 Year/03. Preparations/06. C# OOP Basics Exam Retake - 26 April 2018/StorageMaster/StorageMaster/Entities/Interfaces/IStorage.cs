namespace StorageMaster.Entities.Interfaces
{
    using StorageMaster.Entities.Models.Products;
    using StorageMaster.Entities.Models.Storages;
    using StorageMaster.Entities.Models.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IStorage
    {
        string Name { get; }

        int Capacity { get; }

        int GarageSlots { get; }

        bool IsFull { get; }

        IReadOnlyCollection<Vehicle> Garage { get; }

        IReadOnlyCollection<Product> Products { get; }

        Vehicle GetVehicle(int garageSlot);

        int SendVehicleTo(int garageSlot, Storage deliveryLocation);

        int UnloadVehicle(int garageSlot);
    }
}