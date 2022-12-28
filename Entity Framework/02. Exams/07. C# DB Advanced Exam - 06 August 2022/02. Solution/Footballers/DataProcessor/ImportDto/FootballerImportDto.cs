using Footballers.Data.Models.Enums;
using Footballers.Data.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class FootballerImportDto
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string ContractStartDate { get; set; }

        [Required]
        public string ContractEndDate { get; set; }

        [Required]
        [Range(0, 3)]
        public int PositionType { get; set; }

        [Required]
        [Range(0, 4)]
        public int BestSkillType { get; set; }
    }
}