namespace VaporStore.DataProcessor.Dtos.Import
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Collections.Generic;
    using VaporStore.Data.Models;

    public class ImportUserDto
    {
        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Age")]
        public int Age { get; set; }

        [JsonProperty("Cards")]
        public ICollection<Card> Cards { get; set; }
    }
}