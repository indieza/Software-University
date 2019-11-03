namespace VaporStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VaporStore.Data.Models.Enum;

    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PurchaseType Type { get; set; }

        [Required, RegularExpression("^[0-9A-Z]{4}-[0-9A-Z]{4}-[0-9A-Z]{4}$")]
        public string ProductKey { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, ForeignKey("Card")]
        public int CardId { get; set; }

        public Card Card { get; set; }

        [Required, ForeignKey("Game")]
        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}