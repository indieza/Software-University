using Footballers.Data.Models.Enums;
using Footballers.Data.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class FootballerImportDto
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("ContractStartDate")]
        public string ContractStartDate { get; set; }

        [Required]
        [XmlElement("ContractEndDate")]
        public string ContractEndDate { get; set; }

        [Required]
        [Range(0, 3)]
        [XmlElement("PositionType")]
        public int PositionType { get; set; }

        [Required]
        [Range(0, 4)]
        [XmlElement("BestSkillType")]
        public int BestSkillType { get; set; }
    }
}