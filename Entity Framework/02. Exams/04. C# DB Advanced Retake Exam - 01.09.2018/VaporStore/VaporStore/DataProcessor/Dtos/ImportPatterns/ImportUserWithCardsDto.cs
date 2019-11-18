namespace VaporStore.DataProcessor.Dtos.ImportPatterns
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ImportUserWithCardsDto
    {
        public string Fullname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        [JsonProperty("Cards")]
        public ICollection<ImportCardToUserDto> UserCards { get; set; }
    }
}