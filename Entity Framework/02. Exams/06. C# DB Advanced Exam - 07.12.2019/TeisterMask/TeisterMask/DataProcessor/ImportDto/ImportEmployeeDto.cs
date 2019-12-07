using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [MinLength(3), MaxLength(40), RegularExpression(@"[A-Za-z0-9]+")]
        [JsonProperty("Username")]
        public string Username { get; set; }

        [Required, EmailAddress]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$"), Required]
        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Tasks")]
        public List<int> Tasks { get; set; }
    }
}