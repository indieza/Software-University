namespace Cinema.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Range(0.01, 99999.99), Required]
        public decimal Price { get; set; }

        [ForeignKey("Customer"), Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey("Projection"), Required]
        public int ProjectionId { get; set; }

        public Projection Projection { get; set; }
    }
}