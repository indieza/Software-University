namespace Cinema.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0.01, 99999999999999999.9)]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        [ForeignKey("Projection")]
        public int ProjectionId { get; set; }

        public Projection Projection { get; set; }
    }
}