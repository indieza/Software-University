namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required, MaxLength(50), Column(TypeName = "VARCHAR(50)")]
        public string Name { get; set; }

        [Required]
        public int SquadNumber { get; set; }

        [Required, ForeignKey("Team")]
        public int TeamId { get; set; }

        public Team Team { get; set; }

        [Required, ForeignKey("Position")]
        public int PositionId { get; set; }

        public Position Position { get; set; }

        [Required]
        public bool IsInjured { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new HashSet<PlayerStatistic>();
    }
}