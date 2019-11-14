namespace VaporStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VaporStore.Data.Models.Enums;

    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PurchaseType Type { get; set; }

        [RegularExpression(@"^[0-9A-Z]{4}-[0-9A-Z]{4}-[0-9A-Z]{4}$"), Required]
        public string ProductKey { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("Card"), Required]
        public int CardId { get; set; }

        public Card Card { get; set; }

        [ForeignKey("Game"), Required]
        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}