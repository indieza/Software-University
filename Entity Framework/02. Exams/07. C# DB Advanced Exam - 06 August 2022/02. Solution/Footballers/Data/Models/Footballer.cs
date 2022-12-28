using Footballers.Data.Models.Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text;

namespace Footballers.Data.Models
{
    public class Footballer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public DateTime ContractStartDate { get; set; }

        [Required]
        public DateTime ContractEndDate { get; set; }

        [Required]
        [EnumDataType(typeof(PositionType))]
        public PositionType PositionType { get; set; }

        [Required]
        [EnumDataType(typeof(BestSkillType))]
        public BestSkillType BestSkillType { get; set; }

        [ForeignKey(nameof(Models.Coach)), Required]
        public int CoachId { get; set; }

        public Coach Coach { get; set; }

        public ICollection<TeamFootballer> TeamsFootballers { get; set; } = new HashSet<TeamFootballer>();
    }
}