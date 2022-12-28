using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Footballers.Data.Models
{
    public class TeamFootballer
    {
        [ForeignKey(nameof(Models.Team)), Required]
        public int TeamId { get; set; }

        public Team Team { get; set; }

        [ForeignKey(nameof(Models.Footballer)), Required]
        public int FootballerId { get; set; }

        public Footballer Footballer { get; set; }
    }
}