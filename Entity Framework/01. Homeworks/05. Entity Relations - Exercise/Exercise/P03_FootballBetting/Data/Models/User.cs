namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(50), Column(TypeName = "VARCHAR(50)")]
        public string Username { get; set; }

        [Required, MaxLength(50), Column(TypeName = "VARCHAR(50)")]
        public string Password { get; set; }

        [Required, MaxLength(50), Column(TypeName = "VARCHAR(50)")]
        public string Email { get; set; }

        [Required, MaxLength(50), Column(TypeName = "VARCHAR(50)")]
        public string Name { get; set; }

        [Required, Range(0.01, 999999999999.9)]
        public decimal Balance { get; set; }

        public ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();
    }
}