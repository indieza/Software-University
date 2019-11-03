namespace VaporStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, 999999.9), Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required, ForeignKey("Developer")]
        public int DeveloperId { get; set; }

        public Developer Developer { get; set; }

        [Required, ForeignKey("Genre")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();

        public ICollection<GameTag> GameTags { get; set; } = new HashSet<GameTag>();
    }
}