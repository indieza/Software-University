using System.Collections.Generic;

namespace CarDealer.Models
{
    public class Part
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public ICollection<PartCar> PartCars { get; set; }
    }
}