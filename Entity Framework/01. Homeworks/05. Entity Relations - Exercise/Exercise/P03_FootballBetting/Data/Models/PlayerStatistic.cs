namespace P03_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlayerStatistic
    {
        [Required, ForeignKey("Game")]
        public int GameId { get; set; }

        public Game Game { get; set; }

        [Required, ForeignKey("Player")]
        public int PlayerId { get; set; }

        public Player Player { get; set; }

        [Required]
        public int ScoredGoals { get; set; }

        [Required]
        public int Assists { get; set; }

        [Required]
        public int MinutesPlayed { get; set; }
    }
}