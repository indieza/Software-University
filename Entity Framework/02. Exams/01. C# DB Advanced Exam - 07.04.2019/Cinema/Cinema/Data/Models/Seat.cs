namespace Cinema.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Seat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Hall")]
        public int HallId { get; set; }

        public Hall Hall { get; set; }
    }
}