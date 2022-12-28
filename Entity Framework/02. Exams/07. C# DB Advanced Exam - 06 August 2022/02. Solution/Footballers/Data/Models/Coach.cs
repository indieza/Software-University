using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.Data.Models
{
    public class Coach
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        public ICollection<Footballer> Footballers { get; set; } = new HashSet<Footballer>();
    }
}