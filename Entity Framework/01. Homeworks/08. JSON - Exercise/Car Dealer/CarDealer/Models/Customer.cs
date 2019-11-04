using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}