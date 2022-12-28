using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.Data.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"[a-zA-Z0-9\s.-]+")]
        public string Name { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }

        public ICollection<TeamFootballer> TeamsFootballers { get; set; } = new HashSet<TeamFootballer>();
    }
}