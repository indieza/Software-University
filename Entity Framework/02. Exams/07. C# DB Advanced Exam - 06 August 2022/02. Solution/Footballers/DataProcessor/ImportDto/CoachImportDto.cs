using Footballers.Data.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class CoachImportDto
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("Nationality")]
        public string Nationality { get; set; }

        [XmlArray("Footballers")]
        [XmlArrayItem("Footballer")]
        public FootballerImportDto[] Footballers { get; set; }
    }
}