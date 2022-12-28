using Footballers.Data.Models;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ImportDto
{
    public class TeamImportDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"[a-zA-Z0-9\s.-]+")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        [JsonProperty("Nationality")]
        public string Nationality { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [JsonProperty("Trophies")]
        public int Trophies { get; set; }

        public HashSet<int> Footballers { get; set; }
    }
}