namespace Cinema.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Projection
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Movie)), Required]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [ForeignKey(nameof(Hall)), Required]
        public int HallId { get; set; }

        public Hall Hall { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}