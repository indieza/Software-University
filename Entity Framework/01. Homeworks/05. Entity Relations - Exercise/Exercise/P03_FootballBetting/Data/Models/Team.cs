namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required, MaxLength(20), Column(TypeName = "NVARCHAR(20)")]
        public string Name { get; set; }

        [Required, Column(TypeName = "VARCHAR(MAX)")]
        public string LogoUrl { get; set; }

        [Required, Column(TypeName = "CHAR(3)")]
        public string Initials { get; set; }

        [Required, Range(0.01, 9999.9)]
        public decimal Budget { get; set; }

        [Required, ForeignKey("Color")]
        public int PrimaryKitColorId { get; set; }

        public Color PrimaryKitColor { get; set; }

        [Required, ForeignKey("Color")]
        public int SecondaryKitColorId { get; set; }

        public Color SecondaryKitColor { get; set; }

        [Required, ForeignKey("Town")]
        public int TownId { get; set; }

        public Town Town { get; set; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();

        public ICollection<Game> HomeGames { get; set; } = new HashSet<Game>();

        public ICollection<Game> AwayGames { get; set; } = new HashSet<Game>();
    }
}