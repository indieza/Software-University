namespace StorageMaster.Entities.Models.Vehicles
{
    using StorageMaster.Contracts;
    using StorageMaster.Entities.Interfaces;
    using StorageMaster.Entities.Models.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Vehicle : IVehicle
    {
        private readonly List<IProduct> trunk;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<IProduct>();
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<IProduct> Trunk => this.trunk.AsReadOnly();

        public bool IsFull => this.trunk.Sum(p => p.Weight) >= this.Capacity ? true : false;

        public bool IsEmpty => this.trunk.Count == 0 ? true : false;

        public void LoadProduct(Product product)
        {
            if (this.IsFull == true)
            {
                throw new InvalidOperationException(ExceptionMessages.FullVehicle);
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.trunk.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyVehicle);
            }

            Product product = (Product)this.trunk.LastOrDefault();
            this.trunk.RemoveAt(this.trunk.Count - 1);

            return product;
        }
    }
}