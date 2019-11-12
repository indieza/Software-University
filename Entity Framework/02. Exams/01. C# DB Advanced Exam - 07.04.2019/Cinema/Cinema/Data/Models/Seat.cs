namespace Cinema.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Seat
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Hall"), Required]
        public int HallId { get; set; }

        public Hall Hall { get; set; }
    }
}