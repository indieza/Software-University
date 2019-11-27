namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Item
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3), MaxLength(30), Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Category)), Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Range(0.01, double.MaxValue), Required]
        public decimal Price { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}