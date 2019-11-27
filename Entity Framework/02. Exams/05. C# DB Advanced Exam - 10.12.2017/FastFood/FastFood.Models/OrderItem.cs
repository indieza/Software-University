namespace FastFood.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderItem
    {
        [ForeignKey(nameof(Order)), Required]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [ForeignKey(nameof(Item)), Required]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        [Range(1, int.MaxValue), Required]
        public int Quantity { get; set; }
    }
}