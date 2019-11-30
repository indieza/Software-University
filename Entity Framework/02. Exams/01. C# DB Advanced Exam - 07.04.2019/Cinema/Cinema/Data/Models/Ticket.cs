namespace Cinema.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Range(0.01, double.MaxValue), Required]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Customer)), Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey(nameof(Projection)), Required]
        public int ProjectionId { get; set; }

        public Projection Projection { get; set; }
    }
}