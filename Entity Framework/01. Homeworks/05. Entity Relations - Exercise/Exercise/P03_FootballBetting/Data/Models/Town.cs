namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Town
    {
        [Key]
        public int TownId { get; set; }

        [Required, MaxLength(150), Column(TypeName = "VARCHAR(150)")]
        public string Name { get; set; }

        [Required, ForeignKey("Country")]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}