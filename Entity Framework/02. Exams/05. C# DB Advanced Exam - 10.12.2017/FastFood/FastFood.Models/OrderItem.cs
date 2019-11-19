namespace FastFood.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderItem
    {
        [Key, Required]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Key, Required]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        [Range(1, int.MaxValue), Required]
        public int Quantity { get; set; }
    }
}