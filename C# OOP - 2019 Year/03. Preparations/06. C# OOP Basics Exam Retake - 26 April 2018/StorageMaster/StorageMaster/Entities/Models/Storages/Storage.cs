namespace StorageMaster.Entities.Models.Storages
{
    using StorageMaster.Contracts;
    using StorageMaster.Entities.Interfaces;
    using StorageMaster.Entities.Models.Products;
    using StorageMaster.Entities.Models.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Storage : IStorage
    {
        private List<Product> products;
        private Vehicle[] garage;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.products = new List<Product>();
            this.garage = new Vehicle[garageSlots];

            this.FullGarage(0, vehicles);
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public bool IsFull => this.products.Sum(p => p.Weight) >= this.Capacity ? true : false;

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGarageSlot);
            }

            Vehicle vehicle = this.garage[garageSlot];

            if (vehicle == null)
            {
                throw new InvalidOperationException(ExceptionMessages.NoVehicleInGarage);
            }

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            bool isFreeGarageSlot = deliveryLocation.Garage.Any(g => g == null);

            if (!isFreeGarageSlot)
            {
                throw new InvalidOperationException(ExceptionMessages.NoFreeRoomInGarage);
            }

            this.garage[garageSlot] = null;

            var freeGarageSlotIndex = Array.IndexOf(this.garage, null);
            this.garage[freeGarageSlotIndex] = vehicle;

            return freeGarageSlotIndex;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(ExceptionMessages.FullStorage);
            }

            Vehicle vehicle = GetVehicle(garageSlot);

            int unloadedProductCount = 0;

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                Product product = vehicle.Unload();
                this.products.Add(product);

                unloadedProductCount++;
            }

            return unloadedProductCount;
        }

        private void FullGarage(int v, IEnumerable<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                this.garage[v++] = vehicle;
            }
        }
    }
}