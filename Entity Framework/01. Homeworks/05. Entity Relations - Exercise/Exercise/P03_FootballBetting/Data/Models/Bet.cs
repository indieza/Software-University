namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bet
    {
        [Key]
        public int BetId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required, MaxLength(100), Column(TypeName = "NVARCHAR(100)")]
        public string Prediction { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required, ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required, ForeignKey("Game")]
        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}