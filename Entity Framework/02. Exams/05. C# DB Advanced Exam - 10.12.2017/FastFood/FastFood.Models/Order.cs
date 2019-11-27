namespace FastFood.Models
{
    using FastFood.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public OrderType Type { get; set; }

        [Required, NotMapped]
        public decimal TotalPrice => this.OrderItems.Sum(oi => oi.Quantity * oi.Item.Price);

        [ForeignKey(nameof(Employee)), Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}