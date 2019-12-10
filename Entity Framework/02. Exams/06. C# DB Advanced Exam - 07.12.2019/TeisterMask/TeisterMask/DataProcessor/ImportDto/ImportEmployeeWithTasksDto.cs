namespace TeisterMask.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportEmployeeWithTasksDto
    {
        [JsonProperty("Username")]
        [RegularExpression(@"[A-Za-z0-9]+"), MinLength(3), MaxLength(40), Required]
        public string Username { get; set; }

        [JsonProperty("Email")]
        [EmailAddress, Required]
        public string Email { get; set; }

        [JsonProperty("Phone")]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$"), Required]
        public string Phone { get; set; }

        [JsonProperty("Tasks")]
        public int[] Tasks { get; set; }
    }
}